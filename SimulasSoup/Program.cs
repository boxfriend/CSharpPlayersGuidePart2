var soups = new string[] { "Soup", "Stew", "Gumbo" };
var ingredients = new string[] { "Mushrooms", "Chicken", "Carrots", "Potatoes" };
var seasonings = new string[] { "Spicy", "Salty", "Sweet" };

Console.Title = "Simula's Soup Menu";
Console.WriteLine("Today's Menu:");
DisplayMenu(soups);
var soup = GetValidInput(0,soups.Length);
Console.Clear();
Console.WriteLine("Today's Ingredients:");
DisplayMenu(ingredients);
var ingredient = GetValidInput(0, ingredients.Length);
Console.Clear();
Console.WriteLine("Today's Seasonings:");
DisplayMenu(seasonings);
var seasoning = GetValidInput(0, seasonings.Length);
var recipe = GetRecipe(seasoning, ingredient,soup);
Console.WriteLine($"For today's meal you have chosen {recipe.seasoning} {recipe.ingredient} {recipe.recipe}");

(Seasoning seasoning, Ingredient ingredient, Recipe recipe) GetRecipe(int seasoning, int ingredient, int soup)
{
    var recipe = (Recipe)soup;
    var ingredients = (Ingredient)ingredient;
    var seasonings = (Seasoning)seasoning;
    return (seasonings, ingredients, recipe);
}
int GetValidInput(int min, int max)
{
    Console.Write("Which menu item would you like? ");
    var input = Convert.ToInt32(Console.ReadLine());
    return input > min && input <= max ? input-1 : GetValidInput(min, max);
}
void DisplayMenu (string[] menu)
{
    for(var i = 0; i < menu.Length; i++)
        Console.WriteLine($"{i+1} - {menu[i]}");
}
enum Recipe { Soup, Stew, Gumbo }
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
enum Seasoning { Spicy, Salty, Sweet }
