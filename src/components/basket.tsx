import { FlatList, Text, View, StyleSheet, Button } from "react-native";
import React, { useEffect } from "react";
import { MockMenuItem } from "../mocks/mockMenu";
import { getPriceList } from "../api/actions";
import { useAppDispatch, useAppSelector } from "../app/hooks";

interface IBasket {
  basketItems: MockMenuItem[];
}

export const Basket: React.FC<IBasket> = ({ basketItems }) => {
  const pricelist = useAppSelector((state) => state.pricelist);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(getPriceList());
  }, []);

  return (
    <View style={styles.basket}>
      {basketItems.length === 0 ? (
        <Text style={styles.emptyBasket}>Basket empty</Text>
      ) : (
        <>
          <FlatList
            data={basketItems}
            renderItem={({ item }) => (
              <View style={styles.basketItem}>
                <Text>
                  {item.name}, £{item.price}
                </Text>
              </View>
            )}
            keyExtractor={(item, index) => index.toString()}
          />
          <View>
            <View style={styles.foo}>
              <Text>
                Total:{" "}
                {basketItems.reduce((t, item) => t + item.price, 0).toFixed(2)}
              </Text>
              <Button onPress={() => console.log(pricelist)} title="Send" />
            </View>
            <Text>es</Text>
            {pricelist.loading && <Text>Loading...</Text>}
            {!pricelist.loading && <Text>{pricelist.pricelistHolder}</Text>}
          </View>
        </>
      )}
    </View>
  );
};

const styles = StyleSheet.create({
  basket: { flex: 1, backgroundColor: "#E6E6E6" },
  basketItem: { padding: 10 },
  emptyBasket: { alignContent: "center", alignItems: "center" },
  foo: { flexDirection: "row", marginTop: 30 },
});
