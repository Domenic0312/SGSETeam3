import axios from "axios";

class CatalogService {
  constructor() {}

  async getData() {
    return await axios.get("http://localhost:3000/getAll");
  }
}

export default new CatalogService();
