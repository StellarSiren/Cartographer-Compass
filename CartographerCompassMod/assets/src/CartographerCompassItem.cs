using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

public class CartographerCompassItem : Item
{
    public override void OnHeldInteractStart(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
    {
        if (byEntity.World.Side == EnumAppSide.Client && byEntity.Controls.Sneak)
        {
            ShowCompassInterface();
        }
        handling = EnumHandHandling.PreventDefault;
    }

    private void ShowCompassInterface()
    {
    }
}