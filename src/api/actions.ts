import { createAsyncThunk } from "@reduxjs/toolkit";
import { getPriceListController } from "./controllers/pricelist";
import axios from "axios";

export const getPriceList = createAsyncThunk('pricelist/getPricelist', () => {
    return getPriceListController();
  })