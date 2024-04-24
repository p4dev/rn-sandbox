import { axiosWrapper } from "../httpclient";

export const getPriceListController = () => {
  return axiosWrapper
    .get('/pricelist/601')
    .then(res => res.data);
}