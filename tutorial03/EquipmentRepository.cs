namespace tutorial03;

public class EquipmentRepository
{
    List<Equipment> _equipments;

    public EquipmentRepository()
    {
        _equipments = new List<Equipment>();
    }
    public void AddEquipment(Equipment equipment)
    {
        _equipments.Add(equipment);
    }
    
    public void RemoveEquipment(long equipmentId)
    {
        Equipment? equipmentToRemove = null;
        foreach (var equipment in _equipments)
        {
            if (equipment.Id == equipmentId)
            {
                equipmentToRemove = equipment;
                break;
            }
        }
        if (equipmentToRemove != null)
        {
            _equipments.Remove(equipmentToRemove);
        }
        else
        {
            throw new KeyNotFoundException("Equipment with ID " + equipmentId + " not found.");
        }
    }

    public List<Equipment> GetAllEquipments()
    {
        return _equipments;
    }

    public List<Equipment> GetAvailableEquipments()
    {
        List<Equipment> availableEquipments = new List<Equipment>();
        foreach (var equipment in _equipments)
        {
            if (equipment.IsAvailable)
            {
                availableEquipments.Add(equipment);
            }
        }
        return availableEquipments;
    }

    public Equipment GetEquipmentById(long equipmentId)
    {
        foreach (var equipment in _equipments)
        {
            if (equipment.Id == equipmentId) return equipment;
        }
        throw new KeyNotFoundException("Rental with ID " + equipmentId + " not found.");
    }
}