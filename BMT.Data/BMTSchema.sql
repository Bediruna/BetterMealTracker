CREATE TABLE Food (
    Id INT PRIMARY KEY,
    Name TEXT NOT NULL,
    Brand TEXT,

    -- Macronutrients Per 100g
    Calories FLOAT,
    ProteinG FLOAT,
    FatG FLOAT,
    SaturatedFatG FLOAT,
    TransFatG FLOAT,
    CarbsG FLOAT,
    FiberG FLOAT,
    SugarG FLOAT,
    AddedSugarG FLOAT,

    -- Micronutrients Per 100g
    CholesterolMg FLOAT,
    SodiumMg FLOAT,
    PotassiumMg FLOAT,
    CalciumMg FLOAT,
    IronMg FLOAT,
    VitaminAUg FLOAT,
    VitaminCMg FLOAT,
    VitaminDUg FLOAT,
    VitaminB12Ug FLOAT,
    MagnesiumMg FLOAT,
    ZincMg FLOAT
);

CREATE TABLE ServingOption (
    Id INTEGER PRIMARY KEY,
    FoodId INT NOT NULL REFERENCES Food(Id) ON DELETE CASCADE,
    SizeG FLOAT NOT NULL,
    Description TEXT NOT NULL,
    IsDefault BOOLEAN DEFAULT FALSE
);

CREATE TABLE MealType (
    Id INTEGER PRIMARY KEY,
    Name TEXT NOT NULL UNIQUE
);

CREATE TABLE FoodLog (
    Id INT PRIMARY KEY,
    FoodId INT REFERENCES Food(Id) ON DELETE CASCADE,
    GramsConsumed FLOAT NOT NULL,
    ServingsConsumed FLOAT,
    MealTypeId INT REFERENCES MealType(Id),
    DateConsumed TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Notes TEXT
);

CREATE TABLE VisibleOnLogPage (
    Protein BOOLEAN DEFAULT TRUE,
    Calories BOOLEAN DEFAULT TRUE,
    Fat BOOLEAN DEFAULT TRUE,
    Carbs BOOLEAN DEFAULT TRUE,
    Sugar BOOLEAN DEFAULT TRUE,
    Fiber BOOLEAN DEFAULT TRUE,
    Cholesterol BOOLEAN DEFAULT TRUE,
    Sodium BOOLEAN DEFAULT TRUE,
    Potassium BOOLEAN DEFAULT TRUE,
    Calcium BOOLEAN DEFAULT TRUE,
    Iron BOOLEAN DEFAULT TRUE,
    VitaminA BOOLEAN DEFAULT TRUE,
    VitaminC BOOLEAN DEFAULT TRUE,
    VitaminD BOOLEAN DEFAULT TRUE,
    VitaminB12 BOOLEAN DEFAULT TRUE,
    Magnesium BOOLEAN DEFAULT TRUE,
    Zinc BOOLEAN DEFAULT TRUE
);

CREATE TABLE VisibleOnMainPage(
    MealTypes BOOLEAN DEFAULT TRUE, -- or just show all food logs on the page
    MacrosChart BOOLEAN DEFAULT TRUE,
    Summary BOOLEAN DEFAULT TRUE
);