
import { Text, TouchableOpacity, View, StyleSheet } from 'react-native';


interface IMenuItemRow {
    itemName: string;
    itemPrice: number;
    onItemPressed: () => void;
  }
  
export const MenuItemRow: React.FC<IMenuItemRow> = ({ itemName, itemPrice, onItemPressed }) => {
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
    menuStyles: {flex: 1, justifyContent: 'center', alignItems: 'center', padding:10}, // child
    menuItem: {flex:1, padding: 30, backgroundColor:'#FFFFFF', borderRadius:10},
  });