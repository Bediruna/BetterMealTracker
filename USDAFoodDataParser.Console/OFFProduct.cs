using MongoDB.Bson;

public class Rootobject : BsonDocument
{
    public string _id { get; set; }
    public string lc { get; set; }
    public string[] correctors_tags { get; set; }
    public string[] data_sources_tags { get; set; }
    public object[] data_quality_errors_tags { get; set; }
    public string[] countries_hierarchy { get; set; }
    public string[] categories_tags { get; set; }
    public int rev { get; set; }
    public string categories_old { get; set; }
    public object[] unknown_nutrients_tags { get; set; }
    public object[] removed_countries_tags { get; set; }
    public string packaging_old { get; set; }
    public string[] nutriscore_tags { get; set; }
    public object[] nucleotides_prev_tags { get; set; }
    public string[] data_quality_info_tags { get; set; }
    public string nutriscore_grade { get; set; }
    public string brands_old { get; set; }
    public Categories_Properties categories_properties { get; set; }
    public string[] codes_tags { get; set; }
    public string compared_to_category { get; set; }
    public object[] minerals_prev_tags { get; set; }
    public string ingredients_text_fr { get; set; }
    public string nutrition_grades { get; set; }
    public string[] ecoscore_tags { get; set; }
    public string[] debug_param_sorted_langs { get; set; }
    public string ingredients_text { get; set; }
    public object[] minerals_tags { get; set; }
    public string[] states_tags { get; set; }
    public string product_quantity_unit { get; set; }
    public string product_name { get; set; }
    public object[] other_nutritional_substances_tags { get; set; }
    public int nutrition_score_warning_no_fiber { get; set; }
    public string interface_version_created { get; set; }
    public string origins { get; set; }
    public int created_t { get; set; }
    public object[] traces_hierarchy { get; set; }
    public string[] labels_hierarchy { get; set; }
    public string max_imgid { get; set; }
    public string[] allergens_hierarchy { get; set; }
    public int nutrition_score_beverage { get; set; }
    public string update_key { get; set; }
    public int complete { get; set; }
    public string generic_name { get; set; }
    public string[] languages_hierarchy { get; set; }
    public string emb_codes_orig { get; set; }
    public object[] weighers_tags { get; set; }
    public string[] nutrient_levels_tags { get; set; }
    public string brands_lc { get; set; }
    public string purchase_places { get; set; }
    public Environmental_Score_Data environmental_score_data { get; set; }
    public string nutriscore_version { get; set; }
    public string expiration_date { get; set; }
    public object[] emb_codes_tags { get; set; }
    public string[] pnns_groups_2_tags { get; set; }
    public string generic_name_fr { get; set; }
    public string[] last_edit_dates_tags { get; set; }
    public string[] nutriscore_2021_tags { get; set; }
    public string[] data_quality_warnings_tags { get; set; }
    public string nutrition_data_prepared_per { get; set; }
    public int last_image_t { get; set; }
    public string[] packaging_materials_tags { get; set; }
    public string[] pnns_groups_1_tags { get; set; }
    public string[] misc_tags { get; set; }
    public string categories { get; set; }
    public string nutrition_data { get; set; }
    public object[] data_quality_bugs_tags { get; set; }
    public string[] packaging_recycling_tags { get; set; }
    public string pnns_groups_2 { get; set; }
    public string data_sources { get; set; }
    public string origin { get; set; }
    public string countries_lc { get; set; }
    public string labels_old { get; set; }
    public string pnns_groups_1 { get; set; }
    public string[] languages_tags { get; set; }
    public object[] amino_acids_prev_tags { get; set; }
    public int popularity_key { get; set; }
    public int packagings_complete { get; set; }
    public Packaging2[] packagings { get; set; }
    public Nutriscore nutriscore { get; set; }
    public string traces_from_user { get; set; }
    public string[] categories_properties_tags { get; set; }
    public string[] allergens_tags { get; set; }
    public string allergens_lc { get; set; }
    public string packaging { get; set; }
    public string interface_version_modified { get; set; }
    public string ingredients_text_debug { get; set; }
    public string traces_lc { get; set; }
    public string labels_lc { get; set; }
    public string nova_group_error { get; set; }
    public Images images { get; set; }
    public string[] countries_tags { get; set; }
    public Languages_Codes languages_codes { get; set; }
    public int nutrition_score_warning_fruits_vegetables_nuts_estimate { get; set; }
    public string product_name_fr { get; set; }
    public string creator { get; set; }
    public string origins_lc { get; set; }
    public string states { get; set; }
    public string code { get; set; }
    public string[] editors_tags { get; set; }
    public string[] brands_hierarchy { get; set; }
    public string[] entry_dates_tags { get; set; }
    public object[] origins_hierarchy { get; set; }
    public string[] photographers_tags { get; set; }
    public string[] nutriscore_2023_tags { get; set; }
    public string emb_codes { get; set; }
    public string nutrition_score_debug { get; set; }
    public string last_modified_by { get; set; }
    public string[] brands_tags { get; set; }
    public string[] food_groups_tags { get; set; }
    public string[] nutrition_grades_tags { get; set; }
    public string quantity { get; set; }
    public string nova_group_debug { get; set; }
    public object[] origins_tags { get; set; }
    public string nutrition_data_per { get; set; }
    public object[] ingredients_that_may_be_from_palm_oil_tags { get; set; }
    public int last_modified_t { get; set; }
    public Languages languages { get; set; }
    public string packaging_lc { get; set; }
    public string[] informers_tags { get; set; }
    public string allergens { get; set; }
    public string packaging_text { get; set; }
    public object[] packaging_tags { get; set; }
    public string traces_from_ingredients { get; set; }
    public string[] _keywords { get; set; }
    public string packaging_text_fr { get; set; }
    public string manufacturing_places { get; set; }
    public string countries { get; set; }
    public object[] added_countries_tags { get; set; }
    public string[] packaging_shapes_tags { get; set; }
    public object[] nucleotides_tags { get; set; }
    public string stores { get; set; }
    public string[] data_quality_tags { get; set; }
    public object[] ingredients_from_palm_oil_tags { get; set; }
    public object[] purchase_places_tags { get; set; }
    public int nutriscore_score_opposite { get; set; }
    public string ingredients_text_with_allergens_fr { get; set; }
    public Nutrient_Levels nutrient_levels { get; set; }
    public object[] manufacturing_places_tags { get; set; }
    public string traces { get; set; }
    public string labels { get; set; }
    public Category_Properties category_properties { get; set; }
    public string product_type { get; set; }
    public int nutriscore_score { get; set; }
    public Nutriments nutriments { get; set; }
    public string last_editor { get; set; }
    public int schema_version { get; set; }
    public string[] environmental_score_tags { get; set; }
    public string link { get; set; }
    public string[] popularity_tags { get; set; }
    public float completeness { get; set; }
    public string[] ciqual_food_name_tags { get; set; }
    public string[] nova_groups_tags { get; set; }
    public int unique_scans_n { get; set; }
    public string origin_fr { get; set; }
    public object[] packaging_hierarchy { get; set; }
    public int environmental_score_score { get; set; }
    public string[] labels_tags { get; set; }
    public object[] traces_tags { get; set; }
    public string origins_old { get; set; }
    public Nutriscore_Data nutriscore_data { get; set; }
    public string allergens_from_user { get; set; }
    public object[] vitamins_tags { get; set; }
    public string nutrition_grade_fr { get; set; }
    public string lang { get; set; }
    public string[] last_image_dates_tags { get; set; }
    public object[] stores_tags { get; set; }
    public object[] vitamins_prev_tags { get; set; }
    public int last_updated_t { get; set; }
    public int scans_n { get; set; }
    public int product_quantity { get; set; }
    public object[] main_countries_tags { get; set; }
    public int packagings_n { get; set; }
    public string[] states_hierarchy { get; set; }
    public string nutrition_data_prepared { get; set; }
    public string food_groups { get; set; }
    public string id { get; set; }
    public object[] cities_tags { get; set; }
    public string brands { get; set; }
    public string categories_lc { get; set; }
    public Packagings_Materials packagings_materials { get; set; }
    public string allergens_from_ingredients { get; set; }
    public string no_nutrition_data { get; set; }
    public string[] categories_hierarchy { get; set; }
    public object[] checkers_tags { get; set; }
    public object[] amino_acids_tags { get; set; }
    public string environmental_score_grade { get; set; }
}

public class Categories_Properties
{
    public string agribalyse_food_codeen { get; set; }
    public string ciqual_food_codeen { get; set; }
    public string agribalyse_proxy_food_codeen { get; set; }
}

public class Environmental_Score_Data
{
    public Adjustments adjustments { get; set; }
    public string grade { get; set; }
    public Scores scores { get; set; }
    public int missing_data_warning { get; set; }
    public Missing missing { get; set; }
    public int score { get; set; }
    public string status { get; set; }
    public Grades grades { get; set; }
    public Agribalyse agribalyse { get; set; }
}

public class Adjustments
{
    public Packaging packaging { get; set; }
    public Threatened_Species threatened_species { get; set; }
    public Production_System production_system { get; set; }
    public Origins_Of_Ingredients origins_of_ingredients { get; set; }
}

public class Packaging
{
    public int non_recyclable_and_non_biodegradable_materials { get; set; }
    public float score { get; set; }
    public string warning { get; set; }
    public int value { get; set; }
    public Packaging1[] packagings { get; set; }
}

public class Packaging1
{
    public string quantity_per_unit { get; set; }
    public string material { get; set; }
    public int environmental_score_material_score { get; set; }
    public int number_of_units { get; set; }
    public int food_contact { get; set; }
    public float environmental_score_shape_ratio { get; set; }
    public string shape { get; set; }
    public string recycling { get; set; }
}

public class Threatened_Species
{
    public string warning { get; set; }
}

public class Production_System
{
    public string warning { get; set; }
    public int value { get; set; }
    public object[] labels { get; set; }
}

public class Origins_Of_Ingredients
{
    public string warning { get; set; }
    public int epi_score { get; set; }
    public string[] origins_from_categories { get; set; }
    public Transportation_Scores transportation_scores { get; set; }
    public string[] origins_from_origins_field { get; set; }
    public int epi_value { get; set; }
    public Values values { get; set; }
    public Aggregated_Origins[] aggregated_origins { get; set; }
    public Transportation_Values transportation_values { get; set; }
}

public class Transportation_Scores
{
    public float rs { get; set; }
    public float us { get; set; }
    public float no { get; set; }
    public float al { get; set; }
    public float mt { get; set; }
    public float ly { get; set; }
    public float fr { get; set; }
    public float be { get; set; }
    public float tr { get; set; }
    public float gg { get; set; }
    public float eg { get; set; }
    public float _is { get; set; }
    public float im { get; set; }
    public float ad { get; set; }
    public float ax { get; set; }
    public float nl { get; set; }
    public float ma { get; set; }
    public float gr { get; set; }
    public float bg { get; set; }
    public float lu { get; set; }
    public float ch { get; set; }
    public float ee { get; set; }
    public float cz { get; set; }
    public float sy { get; set; }
    public float ba { get; set; }
    public float se { get; set; }
    public float pt { get; set; }
    public float mk { get; set; }
    public float world { get; set; }
    public float il { get; set; }
    public float lt { get; set; }
    public float me { get; set; }
    public float lb { get; set; }
    public float ro { get; set; }
    public float dz { get; set; }
    public float sk { get; set; }
    public float ps { get; set; }
    public float uk { get; set; }
    public float xk { get; set; }
    public float es { get; set; }
    public float at { get; set; }
    public float sj { get; set; }
    public float ie { get; set; }
    public float md { get; set; }
    public float mc { get; set; }
    public float tn { get; set; }
    public float si { get; set; }
    public float sm { get; set; }
    public float hu { get; set; }
    public float pl { get; set; }
    public float it { get; set; }
    public float dk { get; set; }
    public float gi { get; set; }
    public float cy { get; set; }
    public float je { get; set; }
    public float fo { get; set; }
    public float fi { get; set; }
    public float va { get; set; }
    public float ua { get; set; }
    public float lv { get; set; }
    public float li { get; set; }
    public float hr { get; set; }
    public float de { get; set; }
}

public class Values
{
    public int pt { get; set; }
    public int il { get; set; }
    public int world { get; set; }
    public int mk { get; set; }
    public int sy { get; set; }
    public int cz { get; set; }
    public int se { get; set; }
    public int ba { get; set; }
    public int ro { get; set; }
    public int dz { get; set; }
    public int sk { get; set; }
    public int lt { get; set; }
    public int lb { get; set; }
    public int me { get; set; }
    public int be { get; set; }
    public int fr { get; set; }
    public int _is { get; set; }
    public int eg { get; set; }
    public int gg { get; set; }
    public int tr { get; set; }
    public int no { get; set; }
    public int al { get; set; }
    public int us { get; set; }
    public int rs { get; set; }
    public int ly { get; set; }
    public int mt { get; set; }
    public int ch { get; set; }
    public int lu { get; set; }
    public int bg { get; set; }
    public int gr { get; set; }
    public int ma { get; set; }
    public int nl { get; set; }
    public int ax { get; set; }
    public int ee { get; set; }
    public int im { get; set; }
    public int ad { get; set; }
    public int je { get; set; }
    public int fo { get; set; }
    public int pl { get; set; }
    public int hu { get; set; }
    public int sm { get; set; }
    public int cy { get; set; }
    public int dk { get; set; }
    public int gi { get; set; }
    public int it { get; set; }
    public int li { get; set; }
    public int lv { get; set; }
    public int de { get; set; }
    public int hr { get; set; }
    public int ua { get; set; }
    public int va { get; set; }
    public int fi { get; set; }
    public int at { get; set; }
    public int sj { get; set; }
    public int xk { get; set; }
    public int uk { get; set; }
    public int ps { get; set; }
    public int es { get; set; }
    public int tn { get; set; }
    public int md { get; set; }
    public int mc { get; set; }
    public int si { get; set; }
    public int ie { get; set; }
}

public class Transportation_Values
{
    public int ly { get; set; }
    public int mt { get; set; }
    public int no { get; set; }
    public int al { get; set; }
    public int us { get; set; }
    public int rs { get; set; }
    public int _is { get; set; }
    public int eg { get; set; }
    public int gg { get; set; }
    public int tr { get; set; }
    public int be { get; set; }
    public int fr { get; set; }
    public int ad { get; set; }
    public int im { get; set; }
    public int ee { get; set; }
    public int ch { get; set; }
    public int lu { get; set; }
    public int bg { get; set; }
    public int ma { get; set; }
    public int gr { get; set; }
    public int nl { get; set; }
    public int ax { get; set; }
    public int se { get; set; }
    public int ba { get; set; }
    public int sy { get; set; }
    public int cz { get; set; }
    public int il { get; set; }
    public int world { get; set; }
    public int mk { get; set; }
    public int pt { get; set; }
    public int me { get; set; }
    public int lb { get; set; }
    public int lt { get; set; }
    public int dz { get; set; }
    public int sk { get; set; }
    public int ro { get; set; }
    public int es { get; set; }
    public int uk { get; set; }
    public int xk { get; set; }
    public int ps { get; set; }
    public int sj { get; set; }
    public int at { get; set; }
    public int ie { get; set; }
    public int si { get; set; }
    public int tn { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int cy { get; set; }
    public int gi { get; set; }
    public int dk { get; set; }
    public int it { get; set; }
    public int pl { get; set; }
    public int hu { get; set; }
    public int sm { get; set; }
    public int fo { get; set; }
    public int je { get; set; }
    public int ua { get; set; }
    public int va { get; set; }
    public int fi { get; set; }
    public int de { get; set; }
    public int hr { get; set; }
    public int li { get; set; }
    public int lv { get; set; }
}

public class Aggregated_Origins
{
    public string origin { get; set; }
    public int percent { get; set; }
}

public class Scores
{
    public int _is { get; set; }
    public int eg { get; set; }
    public int gg { get; set; }
    public int tr { get; set; }
    public int be { get; set; }
    public int fr { get; set; }
    public int ly { get; set; }
    public int mt { get; set; }
    public int al { get; set; }
    public int no { get; set; }
    public int us { get; set; }
    public int rs { get; set; }
    public int ee { get; set; }
    public int lu { get; set; }
    public int bg { get; set; }
    public int ch { get; set; }
    public int gr { get; set; }
    public int ma { get; set; }
    public int nl { get; set; }
    public int ax { get; set; }
    public int ad { get; set; }
    public int im { get; set; }
    public int il { get; set; }
    public int world { get; set; }
    public int mk { get; set; }
    public int pt { get; set; }
    public int ba { get; set; }
    public int se { get; set; }
    public int sy { get; set; }
    public int cz { get; set; }
    public int sk { get; set; }
    public int dz { get; set; }
    public int ro { get; set; }
    public int me { get; set; }
    public int lb { get; set; }
    public int lt { get; set; }
    public int sj { get; set; }
    public int at { get; set; }
    public int es { get; set; }
    public int xk { get; set; }
    public int uk { get; set; }
    public int ps { get; set; }
    public int si { get; set; }
    public int tn { get; set; }
    public int mc { get; set; }
    public int md { get; set; }
    public int ie { get; set; }
    public int fo { get; set; }
    public int je { get; set; }
    public int cy { get; set; }
    public int gi { get; set; }
    public int dk { get; set; }
    public int it { get; set; }
    public int pl { get; set; }
    public int hu { get; set; }
    public int sm { get; set; }
    public int de { get; set; }
    public int hr { get; set; }
    public int li { get; set; }
    public int lv { get; set; }
    public int ua { get; set; }
    public int va { get; set; }
    public int fi { get; set; }
}

public class Missing
{
    public int ingredients { get; set; }
    public int labels { get; set; }
    public int origins { get; set; }
    public int packagings { get; set; }
}

public class Grades
{
    public string tr { get; set; }
    public string gg { get; set; }
    public string eg { get; set; }
    public string _is { get; set; }
    public string fr { get; set; }
    public string be { get; set; }
    public string mt { get; set; }
    public string ly { get; set; }
    public string rs { get; set; }
    public string us { get; set; }
    public string no { get; set; }
    public string al { get; set; }
    public string ee { get; set; }
    public string nl { get; set; }
    public string ax { get; set; }
    public string gr { get; set; }
    public string ma { get; set; }
    public string ch { get; set; }
    public string lu { get; set; }
    public string bg { get; set; }
    public string ad { get; set; }
    public string im { get; set; }
    public string world { get; set; }
    public string mk { get; set; }
    public string il { get; set; }
    public string pt { get; set; }
    public string se { get; set; }
    public string ba { get; set; }
    public string cz { get; set; }
    public string sy { get; set; }
    public string sk { get; set; }
    public string dz { get; set; }
    public string ro { get; set; }
    public string me { get; set; }
    public string lb { get; set; }
    public string lt { get; set; }
    public string sj { get; set; }
    public string at { get; set; }
    public string es { get; set; }
    public string ps { get; set; }
    public string uk { get; set; }
    public string xk { get; set; }
    public string si { get; set; }
    public string mc { get; set; }
    public string md { get; set; }
    public string tn { get; set; }
    public string ie { get; set; }
    public string fo { get; set; }
    public string je { get; set; }
    public string it { get; set; }
    public string gi { get; set; }
    public string dk { get; set; }
    public string cy { get; set; }
    public string sm { get; set; }
    public string hu { get; set; }
    public string pl { get; set; }
    public string hr { get; set; }
    public string de { get; set; }
    public string lv { get; set; }
    public string li { get; set; }
    public string fi { get; set; }
    public string va { get; set; }
    public string ua { get; set; }
}

public class Agribalyse
{
    public string code { get; set; }
    public float ef_transportation { get; set; }
    public string name_en { get; set; }
    public float ef_processing { get; set; }
    public float ef_agriculture { get; set; }
    public float co2_packaging { get; set; }
    public string version { get; set; }
    public string agribalyse_food_code { get; set; }
    public float co2_agriculture { get; set; }
    public float co2_processing { get; set; }
    public float ef_total { get; set; }
    public float ef_packaging { get; set; }
    public float co2_total { get; set; }
    public string name_fr { get; set; }
    public string agribalyse_proxy_food_code { get; set; }
    public int score { get; set; }
    public float co2_transportation { get; set; }
    public int co2_consumption { get; set; }
    public string dqr { get; set; }
    public int ef_consumption { get; set; }
    public float ef_distribution { get; set; }
    public float co2_distribution { get; set; }
    public int is_beverage { get; set; }
}

public class Nutriscore
{
    public _2023 _2023 { get; set; }
    public _2021 _2021 { get; set; }
}

public class _2023
{
    public string grade { get; set; }
    public int category_available { get; set; }
    public int nutriscore_computed { get; set; }
    public int nutrients_available { get; set; }
    public int score { get; set; }
    public int nutriscore_applicable { get; set; }
    public Data data { get; set; }
}

public class Data
{
    public int is_red_meat_product { get; set; }
    public Components components { get; set; }
    public int negative_points { get; set; }
    public int positive_points { get; set; }
    public int is_beverage { get; set; }
    public int is_fat_oil_nuts_seeds { get; set; }
    public int count_proteins { get; set; }
    public int is_cheese { get; set; }
    public string[] positive_nutrients { get; set; }
    public string count_proteins_reason { get; set; }
    public int is_water { get; set; }
    public int positive_points_max { get; set; }
    public int negative_points_max { get; set; }
}

public class Components
{
    public Positive[] positive { get; set; }
    public Negative[] negative { get; set; }
}

public class Positive
{
    public string id { get; set; }
    public int points { get; set; }
    public string unit { get; set; }
    public int points_max { get; set; }
    public object value { get; set; }
}

public class Negative
{
    public float value { get; set; }
    public int points_max { get; set; }
    public string unit { get; set; }
    public int points { get; set; }
    public string id { get; set; }
}

public class _2021
{
    public int nutriscore_computed { get; set; }
    public int category_available { get; set; }
    public string grade { get; set; }
    public Data1 data { get; set; }
    public int nutriscore_applicable { get; set; }
    public int score { get; set; }
    public int nutrients_available { get; set; }
}

public class Data1
{
    public float sugars_value { get; set; }
    public int energy_value { get; set; }
    public float fiber_value { get; set; }
    public int proteins_points { get; set; }
    public int saturated_fat_value { get; set; }
    public int sugars_points { get; set; }
    public int energy_points { get; set; }
    public int is_water { get; set; }
    public int sugars { get; set; }
    public int energy { get; set; }
    public int saturated_fat_points { get; set; }
    public int is_cheese { get; set; }
    public int is_fat { get; set; }
    public int proteins { get; set; }
    public int is_beverage { get; set; }
    public int sodium_value { get; set; }
    public int saturated_fat { get; set; }
    public int fiber { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils_value { get; set; }
    public int fiber_points { get; set; }
    public int sodium_points { get; set; }
    public float sodium { get; set; }
    public int positive_points { get; set; }
    public int negative_points { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils_points { get; set; }
    public int fruits_vegetables_nuts_colza_walnut_olive_oils { get; set; }
    public float proteins_value { get; set; }
}

public class Images
{
    public Front_Fr front_fr { get; set; }
    public _2 _2 { get; set; }
    public _1 _1 { get; set; }
    public Nutrition_Fr nutrition_fr { get; set; }
    public Ingredients_Fr ingredients_fr { get; set; }
    public _3 _3 { get; set; }
}

public class Front_Fr
{
    public object x1 { get; set; }
    public object y2 { get; set; }
    public string geometry { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string white_magic { get; set; }
    public Sizes sizes { get; set; }
    public object angle { get; set; }
    public string rev { get; set; }
    public object x2 { get; set; }
    public object y1 { get; set; }
}

public class Sizes
{
    public _100 _100 { get; set; }
    public Full full { get; set; }
    public _400 _400 { get; set; }
    public _200 _200 { get; set; }
}

public class _100
{
    public int h { get; set; }
    public int w { get; set; }
}

public class Full
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _400
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _200
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _2
{
    public string uploader { get; set; }
    public string uploaded_t { get; set; }
    public Sizes1 sizes { get; set; }
}

public class Sizes1
{
    public _1001 _100 { get; set; }
    public Full1 full { get; set; }
    public _4001 _400 { get; set; }
}

public class _1001
{
    public int w { get; set; }
    public int h { get; set; }
}

public class Full1
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _4001
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _1
{
    public string uploader { get; set; }
    public string uploaded_t { get; set; }
    public Sizes2 sizes { get; set; }
}

public class Sizes2
{
    public Full2 full { get; set; }
    public _1002 _100 { get; set; }
    public _4002 _400 { get; set; }
}

public class Full2
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _1002
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _4002
{
    public int w { get; set; }
    public int h { get; set; }
}

public class Nutrition_Fr
{
    public string imgid { get; set; }
    public object normalize { get; set; }
    public Sizes3 sizes { get; set; }
    public int angle { get; set; }
    public object white_magic { get; set; }
    public string y2 { get; set; }
    public string x1 { get; set; }
    public string geometry { get; set; }
    public string y1 { get; set; }
    public string x2 { get; set; }
    public string rev { get; set; }
}

public class Sizes3
{
    public Full3 full { get; set; }
    public _1003 _100 { get; set; }
    public _2001 _200 { get; set; }
    public _4003 _400 { get; set; }
}

public class Full3
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _1003
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _2001
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _4003
{
    public int h { get; set; }
    public int w { get; set; }
}

public class Ingredients_Fr
{
    public string y1 { get; set; }
    public string x2 { get; set; }
    public string rev { get; set; }
    public Sizes4 sizes { get; set; }
    public string angle { get; set; }
    public string white_magic { get; set; }
    public string imgid { get; set; }
    public string normalize { get; set; }
    public string orientation { get; set; }
    public string x1 { get; set; }
    public string y2 { get; set; }
    public string geometry { get; set; }
    public int ocr { get; set; }
}

public class Sizes4
{
    public _4004 _400 { get; set; }
    public _2002 _200 { get; set; }
    public Full4 full { get; set; }
    public _1004 _100 { get; set; }
}

public class _4004
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _2002
{
    public int w { get; set; }
    public int h { get; set; }
}

public class Full4
{
    public int w { get; set; }
    public int h { get; set; }
}

public class _1004
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _3
{
    public string uploader { get; set; }
    public int uploaded_t { get; set; }
    public Sizes5 sizes { get; set; }
}

public class Sizes5
{
    public _4005 _400 { get; set; }
    public _1005 _100 { get; set; }
    public Full5 full { get; set; }
}

public class _4005
{
    public int h { get; set; }
    public int w { get; set; }
}

public class _1005
{
    public int h { get; set; }
    public int w { get; set; }
}

public class Full5
{
    public int h { get; set; }
    public int w { get; set; }
}

public class Languages_Codes
{
    public int fr { get; set; }
}

public class Languages
{
    public int enfrench { get; set; }
}

public class Nutrient_Levels
{
    public string fat { get; set; }
    public string saturatedfat { get; set; }
    public string sugars { get; set; }
    public string salt { get; set; }
}

public class Category_Properties
{
    public string ciqual_food_nameen { get; set; }
}

public class Nutriments
{
    public int nutritionscorefr { get; set; }
    public int saturatedfat_100g { get; set; }
    public int proteins { get; set; }
    public int fruitsvegetablesnutsestimate_100g { get; set; }
    public float sodium_value { get; set; }
    public float salt_100g { get; set; }
    public float salt { get; set; }
    public string fat_unit { get; set; }
    public int energykcal_value_computed { get; set; }
    public float cocoa_serving { get; set; }
    public float sodium { get; set; }
    public int carbohydrates { get; set; }
    public string fruitsvegetablesnutsestimate_unit { get; set; }
    public string carbohydrates_unit { get; set; }
    public int proteins_value { get; set; }
    public int fruitsvegetablesnutsestimate { get; set; }
    public int sugars_value { get; set; }
    public int energy_value { get; set; }
    public float salt_value { get; set; }
    public int nutritionscorefr_100g { get; set; }
    public int saturatedfat_value { get; set; }
    public float cocoa { get; set; }
    public string cocoa_unit { get; set; }
    public int energy { get; set; }
    public int sugars { get; set; }
    public int fruitsvegetablesnutsestimate_value { get; set; }
    public int energykcal { get; set; }
    public string fruitsvegetablesnutsestimate_label { get; set; }
    public int fat_100g { get; set; }
    public string sugars_unit { get; set; }
    public string energy_unit { get; set; }
    public string saturatedfat_unit { get; set; }
    public string cocoa_label { get; set; }
    public int saturatedfat { get; set; }
    public float cocoa_value { get; set; }
    public int fruitsvegetablesnutsestimate_serving { get; set; }
    public int energy_100g { get; set; }
    public int sugars_100g { get; set; }
    public string salt_unit { get; set; }
    public int carbohydrates_100g { get; set; }
    public int fat { get; set; }
    public string energykcal_unit { get; set; }
    public string sodium_unit { get; set; }
    public int energykcal_value { get; set; }
    public int energykcal_100g { get; set; }
    public float sodium_100g { get; set; }
    public int carbohydrates_value { get; set; }
    public float cocoa_100g { get; set; }
    public string proteins_unit { get; set; }
    public int proteins_100g { get; set; }
    public int fat_value { get; set; }
}

public class Nutriscore_Data
{
    public int negative_points { get; set; }
    public int positive_points { get; set; }
    public string[] positive_nutrients { get; set; }
    public Components1 components { get; set; }
    public int is_red_meat_product { get; set; }
    public string grade { get; set; }
    public int is_cheese { get; set; }
    public int count_proteins { get; set; }
    public int positive_points_max { get; set; }
    public int negative_points_max { get; set; }
    public int is_fat_oil_nuts_seeds { get; set; }
    public int is_water { get; set; }
    public int score { get; set; }
    public string count_proteins_reason { get; set; }
    public int is_beverage { get; set; }
}

public class Components1
{
    public Positive1[] positive { get; set; }
    public Negative1[] negative { get; set; }
}

public class Positive1
{
    public string id { get; set; }
    public int points { get; set; }
    public int points_max { get; set; }
    public string unit { get; set; }
    public object value { get; set; }
}

public class Negative1
{
    public float value { get; set; }
    public string id { get; set; }
    public int points { get; set; }
    public int points_max { get; set; }
    public string unit { get; set; }
}

public class Packagings_Materials
{
    public EnGlass englass { get; set; }
    public All all { get; set; }
    public EnMetal enmetal { get; set; }
}

public class EnGlass
{
}

public class All
{
}

public class EnMetal
{
}

public class Packaging2
{
    public string recycling { get; set; }
    public string shape { get; set; }
    public int number_of_units { get; set; }
    public int food_contact { get; set; }
    public string quantity_per_unit { get; set; }
    public string material { get; set; }
}
