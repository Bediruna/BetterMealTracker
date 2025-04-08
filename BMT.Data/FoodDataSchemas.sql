--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: branded_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.branded_food (
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


ALTER TABLE public.branded_food OWNER TO postgres;

--
-- Name: fndds_derivation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fndds_derivation (
    derivation_code text,
    derivation_description text
);


ALTER TABLE public.fndds_derivation OWNER TO postgres;

--
-- Name: fndds_ingredient_nutrient_value; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.fndds_ingredient_nutrient_value (
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


ALTER TABLE public.fndds_ingredient_nutrient_value OWNER TO postgres;

--
-- Name: food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food (
    fdc_id text,
    data_type text,
    description text,
    food_category_id text,
    publication_date text
);


ALTER TABLE public.food OWNER TO postgres;

--
-- Name: food_attribute; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_attribute (
    id text,
    fdc_id text,
    seq_num text,
    food_attribute_type_id text,
    name text,
    value text
);


ALTER TABLE public.food_attribute OWNER TO postgres;

--
-- Name: food_attribute_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_attribute_type (
    id text,
    name text,
    description text
);


ALTER TABLE public.food_attribute_type OWNER TO postgres;

--
-- Name: food_calorie_conversion_factor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_calorie_conversion_factor (
    food_nutrient_conversion_factor_id text,
    protein_value text,
    fat_value text,
    carbohydrate_value text
);


ALTER TABLE public.food_calorie_conversion_factor OWNER TO postgres;

--
-- Name: food_category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_category (
    id text,
    code text,
    description text
);


ALTER TABLE public.food_category OWNER TO postgres;

--
-- Name: food_component; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_component (
    id text,
    fdc_id text,
    name text,
    pct_weight text,
    is_refuse text,
    gram_weight text,
    data_points text,
    min_year_acquired text
);


ALTER TABLE public.food_component OWNER TO postgres;

--
-- Name: food_nutrient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_nutrient (
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


ALTER TABLE public.food_nutrient OWNER TO postgres;

--
-- Name: food_nutrient_conversion_factor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_nutrient_conversion_factor (
    id text,
    fdc_id text
);


ALTER TABLE public.food_nutrient_conversion_factor OWNER TO postgres;

--
-- Name: food_nutrient_derivation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_nutrient_derivation (
    id text,
    code text,
    description text
);


ALTER TABLE public.food_nutrient_derivation OWNER TO postgres;

--
-- Name: food_nutrient_source; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_nutrient_source (
    id text,
    code text,
    description text
);


ALTER TABLE public.food_nutrient_source OWNER TO postgres;

--
-- Name: food_portion; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_portion (
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


ALTER TABLE public.food_portion OWNER TO postgres;

--
-- Name: food_protein_conversion_factor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_protein_conversion_factor (
    food_nutrient_conversion_factor_id text,
    value text
);


ALTER TABLE public.food_protein_conversion_factor OWNER TO postgres;

--
-- Name: food_update_log_entry; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.food_update_log_entry (
    id text,
    description text,
    last_updated text
);


ALTER TABLE public.food_update_log_entry OWNER TO postgres;

--
-- Name: foundation_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.foundation_food (
    fdc_id text,
    "NDB_number" text,
    footnote text
);


ALTER TABLE public.foundation_food OWNER TO postgres;

--
-- Name: input_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.input_food (
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


ALTER TABLE public.input_food OWNER TO postgres;

--
-- Name: lab_method; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lab_method (
    id text,
    description text,
    technique text
);


ALTER TABLE public.lab_method OWNER TO postgres;

--
-- Name: lab_method_code; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lab_method_code (
    lab_method_id text,
    code text
);


ALTER TABLE public.lab_method_code OWNER TO postgres;

--
-- Name: lab_method_nutrient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lab_method_nutrient (
    lab_method_id text,
    nutrient_id text
);


ALTER TABLE public.lab_method_nutrient OWNER TO postgres;

--
-- Name: market_acquisition; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.market_acquisition (
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


ALTER TABLE public.market_acquisition OWNER TO postgres;

--
-- Name: measure_unit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.measure_unit (
    id text,
    name text
);


ALTER TABLE public.measure_unit OWNER TO postgres;

--
-- Name: microbe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.microbe (
    id text,
    "foodId" text,
    method text,
    microbe_code text,
    min_value text,
    max_value text,
    uom text
);


ALTER TABLE public.microbe OWNER TO postgres;

--
-- Name: nutrient; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.nutrient (
    id text,
    name text,
    unit_name text,
    nutrient_nbr text,
    rank text
);


ALTER TABLE public.nutrient OWNER TO postgres;

--
-- Name: retention_factor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.retention_factor (
    n_gid text,
    n_code text,
    "n_foodGroupId" text,
    n_description text
);


ALTER TABLE public.retention_factor OWNER TO postgres;

--
-- Name: sample_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sample_food (
    fdc_id text
);


ALTER TABLE public.sample_food OWNER TO postgres;

--
-- Name: sr_legacy_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sr_legacy_food (
    fdc_id text,
    "NDB_number" text
);


ALTER TABLE public.sr_legacy_food OWNER TO postgres;

--
-- Name: sub_sample_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sub_sample_food (
    fdc_id text,
    fdc_id_of_sample_food text
);


ALTER TABLE public.sub_sample_food OWNER TO postgres;

--
-- Name: sub_sample_result; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sub_sample_result (
    food_nutrient_id text,
    adjusted_amount text,
    lab_method_id text,
    nutrient_name text
);


ALTER TABLE public.sub_sample_result OWNER TO postgres;

--
-- Name: survey_fndds_food; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.survey_fndds_food (
    fdc_id text,
    food_code text,
    wweia_category_code text,
    start_date text,
    end_date text
);


ALTER TABLE public.survey_fndds_food OWNER TO postgres;

--
-- Name: wweia_food_category; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.wweia_food_category (
    wweia_food_category text,
    wweia_food_category_description text
);


ALTER TABLE public.wweia_food_category OWNER TO postgres;

--
-- PostgreSQL database dump complete
--

