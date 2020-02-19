namespace BST
{
    public class Item{
        public int ItemId;
        public string Name;
        public double Price;

        public Item(int id, string name, double price){
            ItemId= id;
            Name = name;
            Price = price;
        }
        
        public override string ToString(){
            return "[ " + ItemId + " " + Name +" " + Price +"]";
        }

    }
}