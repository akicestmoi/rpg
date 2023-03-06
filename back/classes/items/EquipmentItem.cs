public class EquipmentItem: Item, IItem, IEquipmentItem {
    public string SlotType {get;}

    public EquipmentItem(string slotType) {
        this.SlotType = slotType;
    }
}