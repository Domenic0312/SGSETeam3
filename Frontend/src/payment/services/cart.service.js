import axios from "axios";

class CartService {
  constructor() {}

  async deletePassedArticles(articlesToDelete, userId) {
    return await axios.post(
      `${process.env.VUE_APP_CART_SERVICE_URL}/cart/deletePassedArticles/${userId}`,
      articlesToDelete
    );
  }
}

export default new CartService();