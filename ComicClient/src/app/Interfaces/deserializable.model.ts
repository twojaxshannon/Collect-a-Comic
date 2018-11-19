/* Add this to help deserialize objects into classes. */
export interface Deserializable {
    deserialize(input: any): this;
  }