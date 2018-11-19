using ComicAPI.Models.ComicVine;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComicAPI.Services
{
    public class ComicVineService
    {
        // TODO: Ideally, would add plenty of error handling, but may not fit in the scope of the demo.
        // TODO: Can probably break this up into multiple classes for separation of purpose, but leaving as-is for demo.

        private const string _apiHost = "comicvine.gamespot.com";
        private static string _apiScheme = Uri.UriSchemeHttps;
        // TODO: Save API keys to database by user and get from there instead (even if it's all my key).
        // TODO: Default API key should be stored in web config, not a constant here in the code!
        private Dictionary<string, string> _apiBaseQueryItems = new Dictionary<string, string>() { { "format", "json" }, { "api_key", "f4390b75a72fd1628a0091f8e3c458705fceca96" } };
        
        /// <summary>
        /// Instantiate the service with default values.
        /// </summary>
        public ComicVineService()
        {
            
        }


        #region Helper Methods
        /// <summary>
        /// Helper method to convert an object's properties into a Dictionary of string/string key value pairs.
        /// </summary>
        /// <typeparam name="TObjectType">Object type to convert</typeparam>
        /// <param name="objectToConvert">Object to convert</param>
        /// <returns>Converted object properties as a string/string dictionary</returns>
        private Dictionary<string, string> ObjectToDictionary<TObjectType>(TObjectType objectToConvert)
            where TObjectType : new()
        {
            Dictionary<string, string> convertedObject = new Dictionary<string, string>();

            foreach (var property in objectToConvert.GetType().GetProperties())
            {
                var propertyValue = property.GetValue(objectToConvert);
                if (propertyValue != null)
                {
                    convertedObject.Add(property.Name.ToLower(), propertyValue.ToString());
                }
            }

            return convertedObject;
        }

        /// <summary>
        /// From the provided query items, create a string ComicVine can parse as part of a URL query.
        /// This can be used for ComicVine query items like filter or sort, which accept a delimited series of values.
        /// </summary>
        /// <param name="subQueryItems">Query items to be added</param>
        /// <returns>Delimited string value of the query items</returns>
        private string SubQueryBuilder(Dictionary<string, string> subQueryItems)
        {
            string keyValueSeparator = ":";
            string delimiter = ",";

            string subQuery = "";
            int counter = 0;

            foreach (var subQueryItem in subQueryItems)
            {
                counter++;

                subQuery += subQueryItem.Key + keyValueSeparator + subQueryItem.Value;
                if (counter != subQueryItems.Count)
                {
                    subQuery += delimiter;
                }
            }

            return subQuery;
        }
        #endregion


        #region API Core Methods
        /// <summary>
        /// Prepends the base ComicVine api string to convert a relative path into a full Uri.
        /// </summary>
        /// <param name="relativePath">Relative path of the API call</param>
        /// <param name="queryItems">A dictinary of querystring items as name/value pairs.</param>
        /// <returns>Completed Uri for accessing ComicVine based on the relative path</returns>
        private Uri GetFullUri(string relativePath, Dictionary<string, string> queryItems = null)
        {
            UriBuilder uriBuilder = new UriBuilder(_apiScheme, _apiHost);
            uriBuilder.Path = "api/" + relativePath;    // ComicVine API paths all begin with "api/".

            Dictionary<string, string> finalQueries = queryItems == null ?
                _apiBaseQueryItems :
                _apiBaseQueryItems.Concat(queryItems).ToDictionary(x => x.Key, x => x.Value);

            Uri finalUri = new Uri(QueryHelpers.AddQueryString(uriBuilder.Uri.AbsoluteUri, finalQueries));
            return finalUri;
        }

        /// <summary>
        /// Send a GET API request to ComicVine.
        /// Expects a JSON-formatted string as the return value.
        /// </summary>
        /// <param name="relativePath">Relative path of the API call</param>
        /// <returns>Result from ComicVine, formatted as a JSON string</returns>
        private async Task<string> CallComicVineAPIAsync(Uri uri)
        {
            // Create a client to handle the request.
            HttpClient client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            // Add request headers.
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Other");   // A UserAgent must be present or ComicVine will reject the request.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Fetch the response in JSON format.
            HttpResponseMessage response = await client.GetAsync(uri);

            string responseAsJsonString = await response.Content.ReadAsStringAsync();

            return responseAsJsonString;
        }
        
        /// <summary>
        /// Requests a single item from ComicVine matching the given type and ID.
        /// </summary>
        /// <param name="searchTypePath">Relative path of the item to retrieve</param>
        /// <param name="id">Identifying value (in ComicVine) of the item to retrieve</param>
        /// <returns>A single ComicVine response object</returns>
        public async Task<TResponseType> GetOne<TResponseType>(string searchTypePath, int resourceTypeId, int itemId)
        {
            // Basic path for getting a single item by its ID value
            string relativePath = searchTypePath + "/" + resourceTypeId + "-" + itemId;

            Uri uri = GetFullUri(relativePath);

            // Call the API with the assembled path.
            var baseResponse = await CallComicVineAPIAsync(uri);

            var response = JsonConvert.DeserializeObject<TResponseType>(baseResponse);
            
            return response;  // Dev Note: Should probably handle some errors here, but skipped for the demo.
        }


        /// <summary>
        /// Get one or more items from ComicVine based on the provided types and criteria.
        /// </summary>
        /// <typeparam name="TResponseType">Type of response to return</typeparam>
        /// <typeparam name="TSortType">Type of object containing sort criteria</typeparam>
        /// <typeparam name="TFilterType">Type of object containing filter criteria</typeparam>
        /// <param name="searchTypePath">Path to search, such as issues or volume</param>
        /// <param name="sortCriteria">Criteria to append for sorting the returned results</param>
        /// <param name="filterCriteria">Criteria to append for filtering the returned results</param>
        /// <param name="limit">Maximum number of results to return at one time</param>
        /// <param name="offset">Index on which ComicVine will begin returning results</param>
        /// <returns></returns>
        public async Task<TResponseType> GetMany<TResponseType, TSortType, TFilterType>(string searchTypePath, TSortType sortCriteria, TFilterType filterCriteria, int limit = 25, int offset=0)
            where TSortType : new()
            where TFilterType : new()
        {
            Dictionary<string, string> queryItems = new Dictionary<string, string>();

            // TODO: This could probably be cleaned up to reduce duplicated code.
            if (sortCriteria != null)
            {
                queryItems.Add("sort", SubQueryBuilder((ObjectToDictionary(sortCriteria)).ToDictionary(x => x.Key, x => x.Value)));
            }

            if (filterCriteria != null)
            {
                queryItems.Add("filter", SubQueryBuilder((ObjectToDictionary(filterCriteria)).ToDictionary(x => x.Key, x => x.Value)));
            }

            queryItems.Add("limit", limit.ToString());
            queryItems.Add("offset", offset.ToString());


            Uri uri = GetFullUri(searchTypePath, queryItems);
            var response = JsonConvert.DeserializeObject<TResponseType>(await CallComicVineAPIAsync(uri));

            // Preserve the response in order to keep paging info.
            return response;
        }
        #endregion


        #region Get Bundlers
        public async Task<Volume> GetVolume(int volumeId)
        {
            /* TODO: Would actually want to add the resourceId (here, 4050) based on a ResourceType
             * class or at least an enum. Planned, but might not get to it within the scope of the demo. */
            var response = await GetOne<VolumeResponse>("volume", 4050, volumeId);
            return response.Results;
        }

        public async Task<Issue> GetIssue(int issueId)
        {
            var response = await GetOne<IssueResponse>("issue", 4000, issueId);
            return response.Results;
        }

        public async Task<VolumesResponse> GetVolumes(VolumeFilter filter, VolumeSort sort)
        {
            return await GetMany<VolumesResponse, VolumeSort, VolumeFilter>("volumes", sort, filter, 100);
        }

        public async Task<IssuesResponse> GetIssues(IssueFilter filter, IssueSort sort)
        {
            return await GetMany<IssuesResponse, IssueSort, IssueFilter>("issues", sort, filter);
        }
        #endregion Get Bundlers


        /// <summary>
        /// Query the ComicVine API for comic issues matching the given search settings.
        /// </summary>
        /// <param name="searchSettings">Settings by which to search, such as filter or sort criteria</param>
        /// <returns>An IssueResponse object matching the provided settings</returns>
        public async Task<IssuesResponse> SearchComics(ComicSearch searchSettings)
        {
            // TODO: Add options to pass in limiter/offset for paging if time allows.

            List <Volume> volumeList = null;
            if (searchSettings.VolumeFilterCriteria != null)
            {
                // Volume criteria specified, so get the list of matching volumes first.
                var volumesResponse = await GetVolumes(searchSettings.VolumeFilterCriteria, searchSettings.VolumeSortCriteria);
                volumeList = volumesResponse.Results.ToList();
            }

            // Add volume Ids as a delimited string to the Issues filter, to get all issues matching the returned volumes.
            if (volumeList != null)
            {
                string delimitedVolumes = "";
                for (int i = 0; i < volumeList.Count; i++)
                {
                    delimitedVolumes += volumeList[i].Id;
                    if (i < volumeList.Count - 1)
                    {
                        delimitedVolumes += "|";    // Dev Note: Volume Ids can be delimited by a pipe when running the Issues search.
                    }
                }

                if (searchSettings.IssueFilterCriteria == null)
                {
                    searchSettings.IssueFilterCriteria = new IssueFilter(); // If the filter wasn't specified, add one now.
                }

                searchSettings.IssueFilterCriteria.Volume = delimitedVolumes;
            }

            // Return the issues matching all of the filter/sort criteria.
            return await GetIssues(searchSettings.IssueFilterCriteria, searchSettings.IssueSortCriteria);
        }
    }
}
