namespace tutorial03;

public class EquipmentService
{
    private EquipmentRepository _equipments;

    public EquipmentService(EquipmentRepository equipment)
    {
        _equipments = equipment;
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipments.AddEquipment(equipment);
    }

    public void RemoveEquipment(long equipmentId)
    {
        _equipments.RemoveEquipment(equipmentId);    
    }
    
    public List<Equipment> GetAvailableEquipments()
    {
        return _equipments.GetAvailableEquipments();
    }
    
    public Equipment GetEquipmentById(long equipmentId)
    {
        return _equipments.GetEquipment(equipmentId);
    }

    public IReadOnlyList<Equipment> GetEquipments()
    {
        return _equipments.GetAllEquipments();
    }
    
    public void MakeEquipmentUnavailable(long equipmentId, string reason)
    {
        Equipment equipment = _equipments.GetEquipment(equipmentId);
        equipment.MakeUnavailable();
    }
}