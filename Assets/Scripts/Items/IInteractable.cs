namespace Assets.Scripts
{
    interface IInteractableItem
    {
        void Interact();
    }
    interface IEquipbleItem
    {
        void Equip();
        void Drop();
    }
    interface IGun
    {
        void Shoot();
    }
}
