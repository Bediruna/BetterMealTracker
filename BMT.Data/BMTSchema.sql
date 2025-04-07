CREATE TABLE food (
    food_id INT PRIMARY KEY,
    name TEXT NOT NULL,
    brand TEXT,
  
    -- Macronutrients per 100g
    calories FLOAT,
    protein_g FLOAT,
    fat_g FLOAT,
    saturated_fat_g FLOAT,
    trans_fat_g FLOAT,
    carbs_g FLOAT,
    fiber_g FLOAT,
    sugar_g FLOAT,
    added_sugar_g FLOAT,

    -- Micronutrients per 100g
    cholesterol_mg FLOAT,
    sodium_mg FLOAT,
    potassium_mg FLOAT,
    calcium_mg FLOAT,
    iron_mg FLOAT,
    vitamin_a_µg FLOAT,
    vitamin_c_mg FLOAT,
    vitamin_d_µg FLOAT,
    vitamin_b12_µg FLOAT,
    magnesium_mg FLOAT,
    zinc_mg FLOAT
);

CREATE TABLE serving_option (
    serving_id INTEGER PRIMARY KEY,
    food_id INT NOT NULL REFERENCES food(food_id) ON DELETE CASCADE,
    size_g FLOAT NOT NULL,
    description TEXT NOT NULL,
    is_default BOOLEAN DEFAULT FALSE
);

CREATE TABLE meal_type (
    meal_type_id INTEGER PRIMARY KEY,
    name TEXT NOT NULL UNIQUE
);

CREATE TABLE food_log (
    food_log_id INT PRIMARY KEY,
    food_id INT REFERENCES food(food_id) ON DELETE CASCADE,
    grams_eaten FLOAT NOT NULL,
    servings_eaten FLOAT,
    meal_type_id INT REFERENCES meal_type(meal_type_id),
    date_time TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    notes TEXT
);

CREATE TABLE VisibleOnLogPage (
    protein BOOLEAN DEFAULT TRUE,
    calories BOOLEAN DEFAULT TRUE,
    fat BOOLEAN DEFAULT TRUE,
    carbs BOOLEAN DEFAULT TRUE,
    sugar BOOLEAN DEFAULT TRUE,
    fiber BOOLEAN DEFAULT TRUE,
    cholesterol BOOLEAN DEFAULT TRUE,
    sodium BOOLEAN DEFAULT TRUE,
    potassium BOOLEAN DEFAULT TRUE,
    calcium BOOLEAN DEFAULT TRUE,
    iron BOOLEAN DEFAULT TRUE,
    vitamin_a BOOLEAN DEFAULT TRUE,
    vitamin_c BOOLEAN DEFAULT TRUE,
    vitamin_d BOOLEAN DEFAULT TRUE,
    vitamin_b12 BOOLEAN DEFAULT TRUE,
    magnesium BOOLEAN DEFAULT TRUE,
    zinc BOOLEAN DEFAULT TRUE
);
CREATE TABLE VisibleOnMainPage(
    MealTypes BOOLEAN DEFAULT TRUE, -- or just show all food logs on the page
    MacrosChart BOOLEAN DEFAULT TRUE,
    Summary BOOLEAN DEFAULT TRUE
)
