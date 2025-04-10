CREATE TABLE better_food
(
    id integer NOT NULL,
    name text NOT NULL,
    brand text,
    calories real,
    proteing real,
    fatg real,
    saturatedfatg real,
    transfatg real,
    carbsg real,
    fiberg real,
    sugarg real,
    addedsugarg real,
    cholesterolmg real,
    sodiummg real,
    potassiummg real,
    calciummg real,
    ironmg real,
    vitaminaug real,
    vitamincmg real,
    vitamindug real,
    vitaminb12ug real,
    magnesiummg real,
    zincmg real,
    CONSTRAINT better_food_pkey PRIMARY KEY (id)
);

CREATE TABLE better_servingoption
(
    id integer NOT NULL,
    foodid integer NOT NULL,
    sizeg real NOT NULL,
    description text NOT NULL,
    isdefault boolean DEFAULT false
);