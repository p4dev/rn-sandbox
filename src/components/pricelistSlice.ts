import {createSlice} from "@reduxjs/toolkit";
import { getPriceList } from "../api/actions";

export interface PriceListReducerState {
    loading: boolean,
    pricelistHolder: string;
}

const initialState: PriceListReducerState = {
    loading: false,
    pricelistHolder: ""
}

const pricelistSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {},
    extraReducers: builder => {
      builder.addCase(getPriceList.pending, state => {
        state.loading = true;
      });
      builder.addCase(getPriceList.fulfilled, (state, action) => {
        state.loading = false;
        state.pricelistHolder = action.payload;
      });
      builder.addCase(getPriceList.rejected, (state, action) => {
        state.loading = false;
        state.pricelistHolder = "";
      });
    },
  });

  export default pricelistSlice.reducer
  