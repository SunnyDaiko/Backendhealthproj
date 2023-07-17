using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class represents a dictionary containing lists of image links.
    /// Each list is named for the product demographic, category, and type.
    /// </summary>
    public class ProductImages
    {
        public Dictionary<string, List<string>> _imageLists;
        public ProductImages()
        {
            _imageLists = new Dictionary<string, List<string>>();

            _imageLists["_MenBasketballHat"] = new List<string>
            {
              "https://images.footballfanatics.com/texas-longhorns/zephyr-black-texas-longhorns-2023-big-12-mens-basketball-conference-tournament-champions-locker-room-adjustable-hat_ss5_p-200026861+pv-1+u-d55kemzbrbfhj4cbkhao+v-cghxptzyek3hkxpwzqju.jpg?_hv=2&w=900",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS70J0Yd0rvY0hpLzreXhd5tlpUFQoUiqIoTQ&usqp=CAU"
            };

            _imageLists["_MenBasketballJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQM70Kq0_mpRdHXVtlvxBlgbJs_ZKchc0d72w&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTeNanOG49l13DW8R1KAr03MAHGyOBDIiOXHA&usqp=CAU"
            };

            _imageLists["_MenBasketballPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4pkI1lb-8At87vTeSGHMVP1OsUeo8COogoA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScLfueovd1y23kb9lqbgclLqrqYkPe7K4TeA&usqp=CAU"
            };

            _imageLists["_MenBasketballShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQewIteBQs_aoZiuqthOFgTJGrOQS1PKGKBDKMVk9WEu2nRmPdhYfoN6CTLzpBKXReQUY&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdXIkINZfAwOvm81vUXT2lE4cBM-6w791vfA&usqp=CAU"
            };

            _imageLists["_MenBasketballShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmIbF0iFtOgl1MXI702aU_oRs5msMLcrVtXg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_NegPQHVWfinh-7HC3CaZwJTX20Wc68w2pg&usqp=CAU"
            };

            _imageLists["_MenGolfHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiNWybqEQ9hvShFI-u490LURhmiRhfn7lFJA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSh_NPjor_Z8PtTEPsQnDCl5-oJovJZ5wZ_nA&usqp=CAU"
            };

            _imageLists["_MenGolfJacket"] = new List<string>
            {
              "https://dimg.dillards.com/is/image/DillardsZoom/mainProduct/travis-mathew-crystal-cove-2.0-performance-stretch-full-zip-jacket/00000001_zi_7ae65efc-64a5-4635-95ab-b7620e5f842a.jpg",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTeNanOG49l13DW8R1KAr03MAHGyOBDIiOXHA&usqp=CAU"
            };

            _imageLists["_MenGolfPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4pkI1lb-8At87vTeSGHMVP1OsUeo8COogoA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScLfueovd1y23kb9lqbgclLqrqYkPe7K4TeA&usqp=CAU"
            };

            _imageLists["_MenGolfShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQewIteBQs_aoZiuqthOFgTJGrOQS1PKGKBDKMVk9WEu2nRmPdhYfoN6CTLzpBKXReQUY&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdXIkINZfAwOvm81vUXT2lE4cBM-6w791vfA&usqp=CAU"
            };

            _imageLists["_MenGolfShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRmIbF0iFtOgl1MXI702aU_oRs5msMLcrVtXg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ_NegPQHVWfinh-7HC3CaZwJTX20Wc68w2pg&usqp=CAU"
            };

            _imageLists["_MenHockeyHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4QlkY_3g-9ubNIgEXqxy-SQaOVaEATyJNSA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJ8kTvwZue4RlbLoOcws7GBcQHMwT4WzVaBQ&usqp=CAU"
            };

            _imageLists["_MenHockeyJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQx7-7St65uXscqCzyK8vNgEHH6YSjjn2PZ9JhwU6ruYBRuHmimV1i0raqaF6nV1YeFklE&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcToDuE32_15uoVU7bf1Khw-R__-lfrP1mNiQQ&usqp=CAU"
            };

            _imageLists["_MenHockeyPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHWYK18iVWqBD7a5894MPQWSqzTZxS3o2v_w&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQB8GeG9u2lg9pFEh0YlwHqS6vHNWwJvX0qUZ7EU_ZS28Hu2OKvdsCi5R_Q48cTBFST85A&usqp=CAU"
            };

            _imageLists["_MenHockeyShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQqtpWRLJIXpO2ELMRMF4OOdUn6PlyL6XJuw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKFxu-tD7glWNNbK60JBTiifKzsykmjRD6zQ&usqp=CAU"
            };

            _imageLists["_MenHockeyShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdywl4yQdthSCFV7iyjVi34cP0A7I0V44wTw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcScRhptY7MuIiZ9ZddElJc9VapT0z83yWe9vg&usqp=CAU"
            };

            _imageLists["_MenSoccerHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSagFMkTCzyThCBKTk-lZqcNeO_1IBo7H5kSQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOpv7JbtU0Gi2Zr9v0kJ5okh4ELfeV_BJOVA&usqp=CAU"
            };

            _imageLists["_MenSoccerJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmGVOeDDbMCcDRtI8-K0zaA_Ep-nfY_mlUUA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpzIjfEhBMNWHVugRpqspeWNA4VWLvFPwpJw&usqp=CAU"
            };

            _imageLists["_MenSoccerPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTE9-M23WlFMi6kF11TZnhUg5F0bOCRSWBkIA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMF-YlaKbg8MFBDMB97BT87--37JEdsX_BDQ&usqp=CAU"
            };

            _imageLists["_MenSoccerShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQt6waR2ZrTWH9OAGQgvkrRVWdO4uffT6gOoA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT6WTeydl-rCZfM62LmBQWozaMZ8MBBscAVnA&usqp=CAU"
            };

            _imageLists["_MenSoccerShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2rI-wo1Sf9HexwBHQnddacDiGPq7RE5w2yg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDzhjwmzSDstRT_QF-dRLg7ulLZgW-XXiMVw&usqp=CAU"
            };

            _imageLists["_MenWeightliftingHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQBRLlk30LE_IG559sZ8-KqqwdPJc8zhY7K3Q&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR25ovFXwgoOX5wFvE1O2L6sOzjA3AdbaID3g&usqp=CAU"
            };

            _imageLists["_MenWeightliftingJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwuYS4MqgOaHfnuBZ9YPTOn_5dx8dbAKsAFA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRIvpXxeUa_0V6KXKhxVnMH3KCKjyesXrlXng&usqp=CAU"
            };

            _imageLists["_MenWeightliftingPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlJv6sUqjFJ0dFuILpzARrzGFPB_r6aiVjR2cpNG_gJQ3IJr6bgn5bxqAqoR-8nh9H2Ks&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSKVhO4j3f4HOGXLgwFEVd_5Xr3K9qaACKQBRqUedFET8TsL_lFDZnZ1UUx2VCMe3OOwUc&usqp=CAU"
            };

            _imageLists["_MenWeightliftingShoe"] = new List<string>
            {
              "https://hips.hearstapps.com/vader-prod.s3.amazonaws.com/1677164399-screen-shot-2023-02-23-at-9-59-13-am-1677164377.png?crop=0.962xw:0.784xh",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8Lsy25nytiGEaQNrqgIY5ImHUhc8cBqZyniwP5aqbS6hSsbvjk8dRyXyNrT-bSEP6Lh0&usqp=CAU"
            };

            _imageLists["_MenWeightliftingShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTx9AqzKMDJV6it4YWOERE5n0SO-4pDAQ3ysA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTJ0GUfAhRvWOKQBx84pOI2xrebXh59yAytfA&usqp=CAU"
            };

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            _imageLists["_WomenBasketballHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSF0MyZZF6uUjt_4x8rr8gfgVp91uudp9iLrw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZek1BvCLAU9_mj-M5hj6NJfNDvD-_rslzQQ&usqp=CAU"
            };

            _imageLists["_WomenBasketballJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFjA1G0MW9UbcZtUk-cDqwSiousCRCTpdxjg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd7KamjNuBfXBOmJxUEBz1TAkobxa8L5UgHA&usqp=CAU"
            };

            _imageLists["_WomenBasketballPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRloWhhXRxqsT0-qYIUZjjMEi0y7GKW4jD6Ug&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTd7GePAoMx118IYAGTYfk5eXMAh2ibfnXUJw&usqp=CAU"
            };

            _imageLists["_WomenBasketballShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0Q1WMZxbMpFY7D9tDRiZ7W25QTxv6DqwPCg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRBoPntPrGjQEUq81vItpSzIGLBlQA_dyQFKA&usqp=CAU"
            };

            _imageLists["_WomenBasketballShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ5ZdhEh_KwiyyWrjnzsJVP9pMEF_L8maxDyQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyDN76R387DlEwSXgcoIJU8VQ0SYVTCV4f69EcFYhNJhkF9cI1IbTxB5tDrSf0LWUTuRE&usqp=CAU"
            };

            _imageLists["_WomenGolfHat"] = new List<string>
            {
              "https://www.carlsgolfland.com/media/catalog/product/cache/a812aa7ff089d6cec05908af65d97742/p/u/puma_womens_unicorn_p_adjsutable_golf_hat_023822_01.jpg",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRw6WWqBzsfnurhEQ7zbzMrrF3YjNY09BOBgw&usqp=CAU"
            };

            _imageLists["_WomenGolfJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTV8x_CcOH5-0DqQFLLgBUVaA7vhRcRt2oqtA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTyjarI9bgPqroLTaLIH9WW4p-mH5iZ__xL4hIh50IhPFycbe3s1Im5WrklngkxF98-koU&usqp=CAU"
            };

            _imageLists["_WomenGolfPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRQT_iKATB7q3TDmHpzkwcmzyyGwIA4SvWQw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRXNq0soFab3xIu7DQmlckhcaXDEZ9DqAvmOg&usqp=CAU"
            };

            _imageLists["_WomenGolfShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHMYna9VnH8-W5O5nFDJ1uppUP0u-I7ELAng&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7q79G6bOjWSgnWcxa46IpuWSBn392zYtusg&usqp=CAU"
            };

            _imageLists["_WomenGolfShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzE4Q2eOtnyxY8Ka3JhrTJ41S3LsOPHzUFLScLJ_qKlzFQV8zOwlHK8_ZDqR5zK-j8rzA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRArwgleOBUtaC8Vt-3goSLd8TkR6euhcEubQ&usqp=CAU"
            };

            _imageLists["_WomenHockeyHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5dbza4sP1yOGKXi5r-qRa2kE5VUwFoL9cIQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSXbmGC1boq5jeQnmp_RviC9oeNP80drozCqQ&usqp=CAU"
            };

            _imageLists["_WomenHockeyJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9MtTtP8bcirMePaioKwhU74SsvSeoOrlfQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt-hEI6peewMxwlP0y1LRG3ODZZijo7Q51vQ&usqp=CAU"
            };

            _imageLists["_WomenHockeyPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8RD8GvwYAr0c4k0GzONXJmEEkw7dTBg-urA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT5qH8RRdummRLDvaXYlpXrNW0gdiYZjLyixpzo9dDJ1nxA-OwLim0jgcc35E-3klJmUz4&usqp=CAU"
            };

            _imageLists["_WomenHockeyShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCNcT2FJF0wxBs2_Mzw_WvViWMDNBEjNVppw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRD_m3r-50nh91SZUlR04wXpQhwVqPExoCUmA&usqp=CAU"
            };

            _imageLists["_WomenHockeyShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRElUgwvijB43Kr-kms3E_ahcSZplF1cC3arA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgSw0LrNiTSLCkwHsRX2e8XMfoDHst_7qwLw&usqp=CAU"
            };

            _imageLists["_WomenSoccerHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQhXJ7KLNLphfid9AY6TdgnNwlg62KI00wBQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSCmTLoez9tN6vQBLnrmo28aPTTTtzFYGyGA&usqp=CAU"
            };

            _imageLists["_WomenSoccerJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcREMggujSb8S9-qK65rocMLpcooE8vKMDA9jw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnUvV-BGrlqu9a5Yv2cla_sM8nFLixv_4DsoE9M6YMaEHFO6IUal5B6WKMOo5KzjKtsy0&usqp=CAU"
            };

            _imageLists["_WomenSoccerPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHPgQ6A1wBCorfBM9t1gM3cV3Z34RxQCE2YA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3SgaHp34R0Q_Z4qREAR7qegXEZcKp3MSggg&usqp=CAU"
            };

            _imageLists["_WomenSoccerShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQFIuR4wkly8AD2iIbytTymYuKBZGiq3y33xQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRNWuUApljfANWspN7wK6mztMJqT0KGpRMhyg&usqp=CAU"
            };

            _imageLists["_WomenSoccerShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJEc2QDwu3Kqt7Nb2W1rWtXiFLMa8LyAOJUxUZpWeDSmn__0S6O-0b3dhNas_RkrGRY-c&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQ54MQdIhVR2mBnwzCV7__-N-t_DAhUqC6ag&usqp=CAU"
            };

            _imageLists["_WomenWeightliftingHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvDpbAFlagcjPDt--ZsKvHF7taroh_kCXDXg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrvy6SFTHwt662Y4fy6r6319pOJrDkdVrE2w&usqp=CAU"
            };

            _imageLists["_WomenWeightliftingJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGWQQI12irfxx754yRdMZmqL4YFTRhLkmSmQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMivxCjqY5UIXIhcCAj-FvN2HM0XEytW5yuWgfFx8cS6z3G0pr8BQ38_D6OKIj8godL0c&usqp=CAU"
            };

            _imageLists["_WomenWeightliftingPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnSfLvk8M4MOGWb_ije4udyszyoJT3kadbeA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7YJzuScLgvdnjso-GtxloqRqf66rfbh8Mvw&usqp=CAU"
            };

            _imageLists["_WomenWeightliftingShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQlRXhkYSpoW_CvNpMGG89fhpRQ9WSPMYR30g&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRbRz_70UfQ3gGDvRyAjAhBWMamSOylT9fx6g&usqp=CAU"
            };

            _imageLists["_WomenWeightliftingShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTRSFL0_A9286mNsjBUuGjrFsDVEuyn0kxcg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJpUg44Av2e1bRovkamUfil_MXtMUV6NZpzg&usqp=CAU"
            };

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            _imageLists["_KidsBasketballHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS8w7jOIO4PhZMdKPdJFdTCDx9qCYGYvaMlQgwI0zJyIpUlSDypT6iUR2E2tgNii7cO7d0&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6qXGWXRpxaVkWf0vzo4zqIgg648uLzmLChw&usqp=CAU"
            };

            _imageLists["_KidsBasketballJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHH0apEznL0O8g_443-HXmbbMHP2WkcUBTNgDBV0U5BuNnlcK2gNjDbw18oHMmzRqGKL8&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkVK5PhoVVm6ZG3djZENN_NiruYkCA4FpnHw&usqp=CAU"
            };

            _imageLists["_KidsBasketballPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRJ_WGqWhR5ipx49hffEZfJIIzWtS0enYGCpA&usqp=CAU",
              "https://i5.walmartimages.com/asr/1c09a476-c01f-4563-a619-6f8f672960d4_1.03933cccf8305208cf2b54b43f695fe6.jpeg"
            };


            _imageLists["_KidsBasketballShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHu_jKikite7fq_7JyuklKGrOM59yW5wvTJA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1oj_Afwtxba_biG2Erx-4YZiLODtTeuNMTA&usqp=CAU"
            };

            _imageLists["_KidsBasketballShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRoUkuGY255OfsjFWIwE2nMpwVdAonM_yBFeA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5nPi78AMQIkBoMZTMTtw2anCnWYJpH_gMFQ&usqp=CAU"
            };

            _imageLists["_KidsGolfHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzVG7NaYgZ0ESD6ZAb_co8RL4MLeNIcRYo2g&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQIpurT__8wNIUCTiTCb_S9ZU073RSMeA_PCA&usqp=CAU"
            };

            _imageLists["_KidsGolfJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQrumXLCG7RedEo--jh_8T4bK7QZ8EWhr4fwA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3P4gN87XcaHHsNl_7yo4amBP7B0n1WYbX2Q&usqp=CAU"
            };

            _imageLists["_KidsGolfPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTuBpZqlBwkjUmaIgWAa0dNyOlHqgoU63llGQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBGUlGJB3MKMTBjZLlZTAx_WrRKbswOyYhLA&usqp=CAU"
            };


            _imageLists["_KidsGolfShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRL0olbGYXf1yT7jqBvhOPcGePdzdi6EIrPlA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSHnD4ej3jnXq3bSugYSWU7ya2CdEcyoYXw3Q&usqp=CAU"
            };

            _imageLists["_KidsGolfShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPBTuVLA9oWeZnfFys0_vGt-wbwuC2pu2CLA&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpKa-blZbWCSH8l726jdhaq37RoPlxRsInrg&usqp=CAU"
            };

            _imageLists["_KidsHockeyHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1oGoFwdqbq8xa2HWGQMjsyf9WWrY3ZtpT5A&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRrv3zl5BTIYuBl6lwwha6NmnNrZBq6BdFHw&usqp=CAU"
            };

            _imageLists["_KidsHockeyJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOClfqZ_nXNu9B8EpAkAMbtSv1qIRNKETwIg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7MqRi9i0H1QHywm9a4JNICrcDZzjdu8md0g&usqp=CAU"
            };

            _imageLists["_KidsHockeyPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSKzXYLZtTpo8QXNpHq_l3kY4azIPxABabKLFrXyoEOCopuD6bE_lisqqQnEeWazBPfa0w&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ2olAEXnNCqnCzChbSGKr2vUuRW3-1dQy_Aw&usqp=CAU"
            };


            _imageLists["_KidsHockeyShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFIoFyFzd7Xh1bHNmzJydZwrsOQ4EVp6-1fQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT285Ouh5SJgU-SJPq8BtEP4Sepf4uGG8MYjA&usqp=CAU"
            };

            _imageLists["_KidsHockeyShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTQOXTPppfMazMB24NfdGiPCrdNBmb3_yduyw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVdLAt2OD5S6ldMC118E36ussnaolsJHa55w&usqp=CAU"
            };

            _imageLists["_KidsSoccerHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSpzTVaDQJpJfF8dEsb7NY8BDoWz8w_f1EDiQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSO5C4ExR6NckhugX5SsF_zYLqteZQJHnJGPA&usqp=CAU"
            };

            _imageLists["_KidsSoccerJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMXzBrNn6zp5rx596IUIWUMJx2umMTU-h_Bg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8aBmnxGXJTATxbTgyfch6zaK-ChzaH8Tuww&usqp=CAU"
            };

            _imageLists["_KidsSoccerPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS--sgQTBirAdK4PMAepKLelVHd-MuJlzewbg&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRczp6rYZgRe5ZEAmXP2ScfEsf0OMWyXG2H3FOjWf76KfeKWGCshjgKOzHHhKH4v1ySDtA&usqp=CAU"
            };


            _imageLists["_KidsSoccerShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVQ4QAZE5sayZQS9YG9xes-YPZwtw4MynFt0ZETVk5FFKkYNBU_VXKvCJtA-VK6gECzos&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSoj9EzuhMDrEvvUlMrR6wq1NDrlffhPudy3g&usqp=CAU"
            };

            _imageLists["_KidsSoccerShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRHffFaKMbKMdYFR0y83wagHFFsPuFt247D1g&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNXF2ovSAb77SBbNoLAmB6d-fXcW2vQYL1ZxsAlfB6p58BPYayOIaLaCS1eZ8EsBfSJ60&usqp=CAU"
            };

            _imageLists["_KidsWeightliftingHat"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTFHGvcefb3teNMU7GmvvBEXtjwruTgb9t4bw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTNHpUDJ176vRcyPSCwlLIRbV6iBFC001i_lw&usqp=CAU"
            };

            _imageLists["_KidsWeightliftingJacket"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS5ZSxg0581vXutm5tN_1slTJZqIEAHrhr7EcihHygXPULuVA_OIl1mO2FQ1qu2VBwFBWk&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ4IUyoG9-VNfJkToOYFbqMy97BDd8rxx5mng&usqp=CAU"
            };

            _imageLists["_KidsWeightliftingPant"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT44dXxcs61vNDHRaK4DT7eRIInk26AEP-fzw&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQG88ygAe4nWnDKdARoNO2NcB8JeKn8r0WUEw&usqp=CAU"
            };


            _imageLists["_KidsWeightliftingShoe"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT-1y7HumiZusMU-qLFmHQnz0u9Wj9GKJ4Cug&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMc5d86JqGYN5E0AC8_lBOKMAz5d2wi7kfYQ&usqp=CAU"
            };

            _imageLists["_KidsWeightliftingShort"] = new List<string>
            {
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7xyPydELPXpdTzM17iWGdlFJJZSd1SbspoQ&usqp=CAU",
              "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRCAXDBGnIEeNHyE6Tm9DhaEl3E3sxSWjHkfw&usqp=CAU"
            };
        }

    }
}
