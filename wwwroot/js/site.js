// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let apiURL = "https://forkify-api.herokuapp.com/api/v2/recipes"
let apikey = "5ee0d08f-bb31-4155-aa6e-5cbdfc7a7eee";
async function GetRecipes(recipeName,id,isAllShow) {
    let resp = await fetch(`${apiURL}?search=${recipeName}&key=${apikey}`);
    let result = await resp.json();
    let Recipes = isAllShow ? result.data.recipes : result.data.recipes.slice(1, 7);
    showRecipes(Recipes, id);
}
function showRecipes(recipes, id) {
    $.ajax({

        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        type: 'POST',
        url:'/Recipe/GetRecipeCard',
        data: JSON.stringify(recipes),
        success: function (htmlResult) {
           $('#' +id).html(htmlResult);
        }
    });


}
async function getOrderRecipe(id,showId) {
   
    let resp = await fetch(`${apiURL}/${id}?key=${apikey}`);
    let result = await resp.json();
    console.log(result);
    let Recipe = result.data.recipe;
    showOrderRecipeDetsails(Recipe, showId);
}
function showOrderRecipeDetsails(orderRecipeDetails, showId) {
   
    $.ajax({

        url: '/Recipe/ShowOrder',
        data: orderRecipeDetails,
        dataType: 'html',
        type: 'POST',
        success: function (htmlResult) {

            $('#' + showId).html(htmlResult);
        }
    });

}