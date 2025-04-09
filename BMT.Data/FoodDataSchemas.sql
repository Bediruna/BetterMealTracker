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

CREATE TABLE fndds_derivation (
    derivation_code text,
    derivation_description text
);

CREATE TABLE fndds_ingredient_nutrient_value (
    ingredient_code text,
    "Ingredient_description" text,
    "Nutrient_code" text,
    "Nutrient_value" text,
    "Nutrient_value_source" text,
    "FDC_ID" text,
    "Derivation_code" text,
    "SR_AddMod_year" text,
    "Foundation_year_acquired" text,
    "Start_date" text,
    "End_date" text
);

CREATE TABLE food (
    fdc_id text,
    data_type text,
    description text,
    food_category_id text,
    publication_date text
);

CREATE TABLE food_attribute (
    id text,
    fdc_id text,
    seq_num text,
    food_attribute_type_id text,
    name text,
    value text
);

CREATE TABLE food_attribute_type (
    id text,
    name text,
    description text
);

CREATE TABLE food_calorie_conversion_factor (
    food_nutrient_conversion_factor_id text,
    protein_value text,
    fat_value text,
    carbohydrate_value text
);

CREATE TABLE food_category (
    id text,
    code text,
    description text
);

CREATE TABLE food_component (
    id text,
    fdc_id text,
    name text,
    pct_weight text,
    is_refuse text,
    gram_weight text,
    data_points text,
    min_year_acquired text
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

CREATE TABLE food_nutrient_conversion_factor (
    id text,
    fdc_id text
);

CREATE TABLE food_nutrient_derivation (
    id text,
    code text,
    description text
);

CREATE TABLE food_nutrient_source (
    id text,
    code text,
    description text
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

CREATE TABLE food_protein_conversion_factor (
    food_nutrient_conversion_factor_id text,
    value text
);

CREATE TABLE food_update_log_entry (
    id text,
    description text,
    last_updated text
);

CREATE TABLE foundation_food (
    fdc_id text,
    "NDB_number" text,
    footnote text
);

CREATE TABLE input_food (
    id text,
    fdc_id text,
    fdc_id_of_input_food text,
    seq_num text,
    amount text,
    sr_code text,
    sr_description text,
    unit text,
    portion_code text,
    portion_description text,
    gram_weight text,
    retention_code text
);

CREATE TABLE lab_method (
    id text,
    description text,
    technique text
);

CREATE TABLE lab_method_code (
    lab_method_id text,
    code text
);

CREATE TABLE lab_method_nutrient (
    lab_method_id text,
    nutrient_id text
);

CREATE TABLE market_acquisition (
    fdc_id text,
    brand_description text,
    expiration_date text,
    label_weight text,
    location text,
    acquisition_date text,
    sales_type text,
    sample_lot_nbr text,
    sell_by_date text,
    store_city text,
    store_name text,
    store_state text,
    upc_code text
);

CREATE TABLE measure_unit (
    id text,
    name text
);

CREATE TABLE microbe (
    id text,
    "foodId" text,
    method text,
    microbe_code text,
    min_value text,
    max_value text,
    uom text
);

CREATE TABLE nutrient (
    id text,
    name text,
    unit_name text,
    nutrient_nbr text,
    rank text
);

CREATE TABLE retention_factor (
    n_gid text,
    n_code text,
    "n_foodGroupId" text,
    n_description text
);

CREATE TABLE sample_food (
    fdc_id text
);

CREATE TABLE sr_legacy_food (
    fdc_id text,
    "NDB_number" text
);

CREATE TABLE sub_sample_food (
    fdc_id text,
    fdc_id_of_sample_food text
);

CREATE TABLE sub_sample_result (
    food_nutrient_id text,
    adjusted_amount text,
    lab_method_id text,
    nutrient_name text
);

CREATE TABLE survey_fndds_food (
    fdc_id text,
    food_code text,
    wweia_category_code text,
    start_date text,
    end_date text
);

CREATE TABLE wweia_food_category (
    wweia_food_category text,
    wweia_food_category_description text
);
