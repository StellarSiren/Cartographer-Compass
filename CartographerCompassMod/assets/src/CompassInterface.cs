using Vintagestory.API.Client;
using Vintagestory.API.Common;

public class CompassInterface : GuiDialog
{
    public CompassInterface(ICoreClientAPI capi) : base(capi)
    {
    }

    public override string ToggleKeyCombinationCode => "cartographercompassmod:togglecompassinterface";

    public override void OnGuiOpened()
    {
        base.OnGuiOpened();
        SetupDialog();
    }

    private void SetupDialog()
    {
        ClearComposers();
        var composer = capi.Gui.CreateCompo("compassinterface", ElementStdBounds.AutosizedMainDialog)
            .AddDialogTitleBar("Compass Interface", OnTitleBarClose)
            .BeginChildElements()
            .AddStaticText("Set Waypoint", CairoFont.WhiteDetailText(), ElementBounds.Fixed(0, 30, 200, 30))
            .AddTextInput(ElementBounds.Fixed(0, 60, 200, 30), OnWaypointTextChanged)
            .AddSmallButton("Set", OnSetButtonPressed, ElementBounds.Fixed(0, 100, 200, 30))
            .EndChildElements()
            .Compose();
    }

    private void OnTitleBarClose()
    {
        TryClose();
    }

    private void OnWaypointTextChanged(string value)
    {
        // Handle waypoint text change
    }

    private bool OnSetButtonPressed()
    {
        // Handle set button press
        return true;
    }
}