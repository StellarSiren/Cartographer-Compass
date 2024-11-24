using Vintagestory.API.Common;
using Vintagestory.API.Client;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

public class CartographerCompassMod : ModSystem
{
    private ICoreAPI api;

    public override void Start(ICoreAPI api)
    {
        this.api = api;
        api.RegisterItemClass("CartographerCompassItem", typeof(CartographerCompassItem));
        api.RegisterEntityBehaviorClass("CompassNavigationBehavior", typeof(CompassNavigationBehavior));
        RegisterCompassRecipe(api);
    }

    private void RegisterCompassRecipe(ICoreAPI api)
    {
        var recipe = new GridRecipe()
        {
            IngredientPattern = new[] { " I ", " S ", " I " },
            Ingredients = new Dictionary<string, CraftingRecipeIngredient>
            {
                { "I", new CraftingRecipeIngredient() { Type = EnumItemClass.Item, Code = new AssetLocation("iron-ingot") } },
                { "S", new CraftingRecipeIngredient() { Type = EnumItemClass.Item, Code = new AssetLocation("steel-gear") } }
            },
            Output = new CraftingRecipeOutput() { Code = new AssetLocation("cartographercompass") }
        };
        api.RegisterRecipe(recipe);
    }
}