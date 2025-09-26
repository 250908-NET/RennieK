# The CookBook
## The purpose of this project is to store a Cookbook for a single user 

Then end points:

/cookbook/Ingredients: returns All Ingredients 

### GET

/cookbook/Ingredients/{name}

- return a single Ingredient by name

/cookbook/Recipe:
-  returns All Recipes

/cookbook/Recipe/{name}
- returns a Recipe by name
### POST
/cookbook/Ingredient/add/
- adds a single ingredient by name

/cookbook/Recipe/add/
- Adds a Recipe

/cookbook/Recipe/update/{nameOfRecipe}/
- adds an Ingrdient to a recipe 

### Delete
/cookbook/Ingredient/remove/{name}
- remove a single ingredient 

/cookbook/Recipe/remove/{RecipeName} 
- removes a entire recipe by name

/cookbook/Recipe/remove
- removes an ingredient from a  recipe


