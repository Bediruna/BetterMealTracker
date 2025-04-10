CREATE TABLE branded_food (
    fdc_id text,
    brand_owner text,
    brand_name text,
    subbrand_name text,
    gtin_upc text,
    ingredients text,
    not_a_significant_source_of text,
    serving_size text,
    serving_size_unit text,
    household_serving_fulltext text,
    branded_food_category text,
    data_source text,
    package_weight text,
    modified_date text,
    available_date text,
    market_country text,
    discontinued_date text,
    preparation_state_code text,
    trade_channel text,
    short_description text,
    material_code text
);

CREATE TABLE food (
    fdc_id text,
    data_type text,
    description text,
    food_category_id text,
    publication_date text
);

CREATE TABLE food_nutrient (
    id text,
    fdc_id text,
    nutrient_id text,
    amount text,
    data_points text,
    derivation_id text,
    min text,
    max text,
    median text,
    loq text,
    footnote text,
    min_year_acquired text,
    percent_daily_value text
);

CREATE TABLE food_portion (
    id text,
    fdc_id text,
    seq_num text,
    amount text,
    measure_unit_id text,
    portion_description text,
    modifier text,
    gram_weight text,
    data_points text,
    footnote text,
    min_year_acquired text
);

CREATE TABLE foundation_food (
    fdc_id text,
    "NDB_number" text,
    footnote text
);

CREATE TABLE measure_unit (
    id text,
    name text
);

CREATE TABLE nutrient (
    id text,
    name text,
    unit_name text,
    nutrient_nbr text,
    rank text
);

CREATE TABLE sr_legacy_food (
    fdc_id text,
    "NDB_number" text
);

CREATE TABLE survey_fndds_food (
    fdc_id text,
    food_code text,
    wweia_category_code text,
    start_date text,
    end_date text
);