import { StatusBar } from 'expo-status-bar';
import { useState } from 'react';
import { StyleSheet, Text, View, FlatList, SafeAreaView, TouchableOpacity } from 'react-native';

interface MockMenuItem {
  name: string; 
  id: string; 
  price: number;
}

const menuItems: MockMenuItem[] = [
  {
    id: "1",
    name: "Pizza",
    price: 10.99
  },
  {
    id: "2",
    name: "Burger",
    price: 10.99
  },
  {
    id: "3",
    name: "Pasta",
    price: 10.99
  },
  {
    id: "4",
    name: "Steak",
    price: 10.99
  },
  {
    id: "5",
    name: "Chicken",
    price: 10.99
  },
  {
    id: "6",
    name: "Chips",
    price: 10.99
  },
  {
    id: "7",
    name: "Waffles",
    price: 10.99
  },
  {
    id: "8",
    name: "Fajitas",
    price: 10.99
  },
  {
    id: "9",
    name: "Ice Cream",
    price: 10.99
  },
  {
    id: "10",
    name: "Shrimp",
    price: 10.99
  }
]


interface IBasket {
  basketItems: MockMenuItem[];
}
const Basket: React.FC<IBasket> = ({
  basketItems
}) => {
  return(
     <View style={styles.basket}>
      {basketItems.length === 0 ? (
        <Text style={styles.emptyBasket}>Basket empty</Text>
      ) : (
        <View>
          <FlatList 
          data={basketItems}
          renderItem={({item}) => 
          <View style={styles.basketItem}>
            <Text>{item.name}, £{item.price}</Text>
          </View>
          }
          keyExtractor={(item, index) => index.toString()}/>
          <Text>Total: {(basketItems.reduce((t, item) => t + item.price, 0).toFixed(2))}</Text>
      </View>
    )}
     </View>
  )
}

export default function App() {
  // const [billList, setBillList] = useState<MockMenuItem[]>([]);
  const [basketItems, setBasketItems] = useState<MockMenuItem[]>([])

  const onMenuItemPressed = (item: MockMenuItem) => {
    setBasketItems([...basketItems, item])
  } 

  return (
    <SafeAreaView  style={styles.wrapper}>
      <Basket basketItems={basketItems} />
      <View style={styles.container}>
        <FlatList 
            data={menuItems}
            renderItem={({item}) => 
              <MenuItemRow 
                itemName={item.name} 
                itemPrice={item.price}
                onItemPressed={() => onMenuItemPressed(item)}/>}
            keyExtractor={item => item.id}
            numColumns={2}/>
      </View>
      <StatusBar style="auto" />
    </SafeAreaView>
  );
}


interface IMenuItemRow {
  itemName: string;
  itemPrice: number;
  onItemPressed: () => void;
}

const MenuItemRow: React.FC<IMenuItemRow> = ({ itemName, itemPrice, onItemPressed }) => {
  return (
    <View style={styles.menuStyles}>
      <TouchableOpacity style={styles.menuItem} onPress={onItemPressed}>
        <Text>{itemName}</Text>
        <Text>{itemPrice}</Text>
      </TouchableOpacity>
    </View>
  )
}

const styles = StyleSheet.create({
  wrapper: {flex: 1, flexDirection:'row', marginTop:30},
  container: {flex: 3, backgroundColor: '#ADD8E6'}, // parent
  menuStyles: {flex: 1, justifyContent: 'center', alignItems: 'center', padding:10}, // child
  menuItem: {flex:1, padding: 30, backgroundColor:'#FFFFFF', borderRadius:10},
  basket: { flex: 1, backgroundColor:'#E6E6E6'},
  basketItem: {padding:10},
  emptyBasket: {flex: 1, alignContent:'center', alignItems:'center'}
});
