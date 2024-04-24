import { StatusBar } from 'expo-status-bar';
import React, { useState } from 'react';
import { StyleSheet, View, FlatList, SafeAreaView } from 'react-native';
import { MockMenuItem, menuItems } from './src/mocks/mockMenu';
import { MenuItemRow } from './src/components/menuItemRow';
import { Basket } from './src/components/basket';
import store from './src/app/store';
import { Provider } from 'react-redux';

export default function App() {
  const [basketItems, setBasketItems] = useState<MockMenuItem[]>([])

  const onMenuItemPressed = (item: MockMenuItem) => {
    setBasketItems([...basketItems, item])
  } 

  return (
    <Provider store={store}>
      <SafeAreaView  style={styles.wrapper}>
        <Basket 
          basketItems={basketItems} />
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
    </Provider>
  );
}

const styles = StyleSheet.create({
  wrapper: {flex: 1, flexDirection:'row', marginTop:30},
  container: {flex: 3, backgroundColor: '#ADD8E6'},
});
