using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Qimmah.Data.Localization;
using Qimmah.Enums.Localization;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace Qimmah.Data.configuration.localization
{
    public class LocalizationConfigurations
    {
        public LocalizationConfigurations(ModelBuilder builder)
        {
            var EnglishString = LanguageTypes.English.ToString();
            var EnglishInt = (int)LanguageTypes.English;
            var ArabicString = LanguageTypes.Arabic.ToString();
            var ArabicInt = (int)LanguageTypes.Arabic;

            builder.Entity<Languages>(entity =>
            {
                entity.ToTable(schema: "Localization", name: "Language");
                entity.HasData(new Languages { ID = EnglishInt, LanguageName = EnglishString, Description = "en", Direction = Direction.ltr.ToString() });
                entity.HasData(new Languages { ID = ArabicInt, LanguageName = ArabicString, Description = "ar", Direction = Direction.rtl.ToString() });
            });


            builder.Entity<Dictionary>(entity =>
            {
                entity.ToTable(schema: "Localization", name: "Dictionary");

                var dictionaryEntries = new List<Dictionary>();

                /*DictionaryLocalization.ID.Max +1*/
                for (int i = 1; i <= 1000; i++)
                {
                    dictionaryEntries.Add(new Dictionary { ID = i });
                }

                entity.HasData(dictionaryEntries);
            });

            builder.Entity<DictionaryLocalization>(entity =>
            {
                entity.ToTable(schema: "Localization", name: "DictionaryLocalization");
                entity.HasKey(u => new { u.ID, u.LanguageID });

                entity.HasOne(u => u.Language)
                      .WithMany()
                      .HasForeignKey(u => u.LanguageID);

                entity.HasOne(u => u.Dictionary)
                      .WithMany()
                      .HasForeignKey(u => u.ID);


                int EnglishInt = 1;
                int ArabicInt = 2;

                entity.HasData(new DictionaryLocalization { ID = 1, LanguageID = EnglishInt, Description = "AYITS" });
                entity.HasData(new DictionaryLocalization { ID = 1, LanguageID = ArabicInt, Description = "AYITS" });

                entity.HasData(new DictionaryLocalization { ID = 2, LanguageID = EnglishInt, Description = "Arab Youth Innovation & Technology Summit" });
                entity.HasData(new DictionaryLocalization { ID = 2, LanguageID = ArabicInt, Description = "قمة الابتكار والتكنولوجيا للشباب العربي" });

                entity.HasData(new DictionaryLocalization { ID = 3, LanguageID = EnglishInt, Description = "Begin your journey toward an Arab future led by innovation" });
                entity.HasData(new DictionaryLocalization { ID = 3, LanguageID = ArabicInt, Description = "ابدأ رحلتك نحو مستقبل عربي تقوده الابتكار" });

                entity.HasData(new DictionaryLocalization { ID = 4, LanguageID = EnglishInt, Description = "from the Land of Civilizations… the Arab Innovation Summit Begins" });
                entity.HasData(new DictionaryLocalization { ID = 4, LanguageID = ArabicInt, Description = "من أرض الحضارات… تنطلق قمة الابتكار العربي" });

                entity.HasData(new DictionaryLocalization { ID = 5, LanguageID = EnglishInt, Description = "Hashemite Kingdom of Jordan" });
                entity.HasData(new DictionaryLocalization { ID = 5, LanguageID = ArabicInt, Description = "ٱلْمَمْلَكَةُ ٱلْأُرْدُنِّيَّةُ ٱلْهَاشِمِيَّةُ" });

                entity.HasData(new DictionaryLocalization { ID = 6, LanguageID = EnglishInt, Description = "King Hussein Bin Talal Convention Center – Dead Sea" });
                entity.HasData(new DictionaryLocalization { ID = 6, LanguageID = ArabicInt, Description = "مركز الملك الحسين بن طلال للمؤتمرات – البحر الميت" });

                entity.HasData(new DictionaryLocalization { ID = 7, LanguageID = EnglishInt, Description = "9:00 AM – The Start of Arab Transformation" });
                entity.HasData(new DictionaryLocalization { ID = 7, LanguageID = ArabicInt, Description = "التاسعة صباحاً – انطلاقة التغيير العربي" });

                entity.HasData(new DictionaryLocalization { ID = 8, LanguageID = EnglishInt, Description = "Join the Changemakers Now" });
                entity.HasData(new DictionaryLocalization { ID = 8, LanguageID = ArabicInt, Description = "انضم إلى صُنّاع التغيير الآن" });

                entity.HasData(new DictionaryLocalization { ID = 9, LanguageID = EnglishInt, Description = "Explore Summit Details" });
                entity.HasData(new DictionaryLocalization { ID = 9, LanguageID = ArabicInt, Description = "استكشف تفاصيل القمة" });

                entity.HasData(new DictionaryLocalization { ID = 10, LanguageID = EnglishInt, Description = "Day One – (Date & Time)" });
                entity.HasData(new DictionaryLocalization { ID = 10, LanguageID = ArabicInt, Description = "اليوم الأول – (بموعد وتاريخ)" });

                entity.HasData(new DictionaryLocalization { ID = 11, LanguageID = EnglishInt, Description = "Official Opening Session with Key Dignitaries" });
                entity.HasData(new DictionaryLocalization { ID = 11, LanguageID = ArabicInt, Description = "الجلسة الافتتاحية الرسمية بمشاركة كبار الشخصيات" });

                entity.HasData(new DictionaryLocalization { ID = 12, LanguageID = EnglishInt, Description = "Opening of the Arab Smart Innovation Exhibition" });
                entity.HasData(new DictionaryLocalization { ID = 12, LanguageID = ArabicInt, Description = "افتتاح المعرض العربي للابتكار الذكي" });

                entity.HasData(new DictionaryLocalization { ID = 13, LanguageID = EnglishInt, Description = "Key Sessions on Digital Transformation and Education" });
                entity.HasData(new DictionaryLocalization { ID = 13, LanguageID = ArabicInt, Description = "جلسات محورية حول التحول الرقمي والتعليم" });

                entity.HasData(new DictionaryLocalization { ID = 14, LanguageID = EnglishInt, Description = "Explore the Day’s Agenda" });
                entity.HasData(new DictionaryLocalization { ID = 14, LanguageID = ArabicInt, Description = "اكتشف برنامج اليوم" });

                entity.HasData(new DictionaryLocalization { ID = 15, LanguageID = EnglishInt, Description = "Day Two – (Date & Time)" });
                entity.HasData(new DictionaryLocalization { ID = 15, LanguageID = ArabicInt, Description = "اليوم الثاني – (بموعد وتاريخ)" });

                entity.HasData(new DictionaryLocalization { ID = 16, LanguageID = EnglishInt, Description = "Sectoral Sessions (Health, Tourism, Agriculture)" });
                entity.HasData(new DictionaryLocalization { ID = 16, LanguageID = ArabicInt, Description = "جلسات قطاعية (صحة، سياحة، زراعة)" });

                entity.HasData(new DictionaryLocalization { ID = 17, LanguageID = EnglishInt, Description = "Presentations of Promising Youth Projects" });
                entity.HasData(new DictionaryLocalization { ID = 17, LanguageID = ArabicInt, Description = "عروض لمشاريع شبابية واعدة" });

                entity.HasData(new DictionaryLocalization { ID = 18, LanguageID = EnglishInt, Description = "Specialized Discussion Forums with Thought Leaders and Executives" });
                entity.HasData(new DictionaryLocalization { ID = 18, LanguageID = ArabicInt, Description = "جلسات نقاشية متخصصة بمشاركة قادة فكر وتنفيذيين" });

                entity.HasData(new DictionaryLocalization { ID = 19, LanguageID = EnglishInt, Description = "Youth Leadership Debates" });
                entity.HasData(new DictionaryLocalization { ID = 19, LanguageID = ArabicInt, Description = "مناظرات شبابية قيادية" });

                entity.HasData(new DictionaryLocalization { ID = 20, LanguageID = EnglishInt, Description = "Arab Innovation Competitions" });
                entity.HasData(new DictionaryLocalization { ID = 20, LanguageID = ArabicInt, Description = "مسابقات الابتكار العربي" });

                entity.HasData(new DictionaryLocalization { ID = 21, LanguageID = EnglishInt, Description = "Presentation of Summit Recommendations & Future Roadmap" });
                entity.HasData(new DictionaryLocalization { ID = 21, LanguageID = ArabicInt, Description = "عرض توصيات القمة وخطة الطريق المستقبلية" });


                entity.HasData(new DictionaryLocalization { ID = 22, LanguageID = EnglishInt, Description = "About the Summit" });
                entity.HasData(new DictionaryLocalization { ID = 22, LanguageID = ArabicInt, Description = "عن القمة" });

                entity.HasData(new DictionaryLocalization { ID = 23, LanguageID = EnglishInt, Description = "Vision" });
                entity.HasData(new DictionaryLocalization { ID = 23, LanguageID = ArabicInt, Description = "الرؤية:" });

                entity.HasData(new DictionaryLocalization { ID = 24, LanguageID = EnglishInt, Description = "By 2030, AYITS will stand as a pivotal turning point that redefined the role of Arab youth as leaders in the global digital economy. It will serve as an integrated platform that unites innovation and technology efforts across the Arab world, leading the region toward excellence in the sustainable knowledge economy." });
                entity.HasData(new DictionaryLocalization { ID = 24, LanguageID = ArabicInt, Description = "بحلول 2030، تصبح AYITS نقطة التحول المفصلية التي أعادت تعريف دور الشباب العربي كقادة للاقتصاد الرقمي العالمي، ومنصة متكاملة توحد جهود الابتكار والتكنولوجيا في العالم العربي لتقود المنطقة نحو الريادة في الاقتصاد المعرفي المستدام.  (المعلومات التالية بناءا على ملف الخطة الاستراتيجية)" });

                entity.HasData(new DictionaryLocalization { ID = 25, LanguageID = EnglishInt, Description = "Mission" });
                entity.HasData(new DictionaryLocalization { ID = 25, LanguageID = ArabicInt, Description = "الرسالة:" });

                entity.HasData(new DictionaryLocalization { ID = 26, LanguageID = EnglishInt, Description = "To empower Arab youth to lead the region’s digital transformation through an open knowledge ecosystem, strategic partnership networks, and innovative support for promising projects—while strengthening their role in technology policymaking and shaping a sustainable future through technology." });
                entity.HasData(new DictionaryLocalization { ID = 26, LanguageID = ArabicInt, Description = "تمكين الشباب العربي من قيادة التحول الرقمي في المنطقة عبر بيئة معرفية مفتوحة، شبكات شراكة استراتيجية، ودعم مبتكر للمشاريع الواعدة، مع تعزيز دورهم في السياسات التقنية وصناعة مستقبل مستدام بالتكنولوجيا." });

                entity.HasData(new DictionaryLocalization { ID = 27, LanguageID = EnglishInt, Description = "Objectives:" });
                entity.HasData(new DictionaryLocalization { ID = 27, LanguageID = ArabicInt, Description = "الأهداف:" });

                entity.HasData(new DictionaryLocalization { ID = 28, LanguageID = EnglishInt, Description = "AYITS 2025 aspires to turn its vision into tangible outcomes through a set of strategic objectives, including:" });
                entity.HasData(new DictionaryLocalization { ID = 28, LanguageID = ArabicInt, Description = "تطمح AYITS 2025 إلى تحويل رؤيتها إلى نتائج عملية، من خلال أهداف استراتيجية تشمل:" });

                entity.HasData(new DictionaryLocalization { ID = 29, LanguageID = EnglishInt, Description = "Launching cross-border Arab projects and alliances" });
                entity.HasData(new DictionaryLocalization { ID = 29, LanguageID = ArabicInt, Description = "إطلاق مشاريع وتحالفات عربية عابرة للحدود" });

                entity.HasData(new DictionaryLocalization { ID = 30, LanguageID = EnglishInt, Description = "What is It?" });
                entity.HasData(new DictionaryLocalization { ID = 30, LanguageID = ArabicInt, Description = "ما هي؟" });

                entity.HasData(new DictionaryLocalization { ID = 31, LanguageID = EnglishInt, Description = "The Arab Youth Innovation & Technology Summit (AYITS) is a leading regional platform that brings together young innovators, decision-makers, and experts in one place to redefine the role of youth in driving digital transformation and sustainable development. Held in Amman — the Arab Youth Capital 2025 — under the umbrella of the League of Arab States, the summit serves as a unique meeting point between youthful energy and institutional opportunities, generating real solutions to the Arab world’s most pressing challenges." });
                entity.HasData(new DictionaryLocalization { ID = 31, LanguageID = ArabicInt, Description = "قمة الابتكار والتكنولوجيا للشباب العربي هي منصة إقليمية رائدة، تجمع الشباب المبتكرين وصنّاع القرار والخبراء في مكان واحد، لإعادة تعريف دور الشباب في قيادة التحول الرقمي والتنمية المستدامة.\r\nتنعقد القمة في عمّان، عاصمة الشباب العربي 2025، تحت مظلة جامعة الدول العربية، وتُعد نقطة التقاء استثنائية بين الطاقات الشابة والفرص المؤسسية لتوليد حلول فعلية لتحديات العالم العربي." });

                entity.HasData(new DictionaryLocalization { ID = 32, LanguageID = EnglishInt, Description = "Why?" });
                entity.HasData(new DictionaryLocalization { ID = 32, LanguageID = ArabicInt, Description = "لماذا؟" });

                entity.HasData(new DictionaryLocalization { ID = 33, LanguageID = EnglishInt, Description = "Because youth are the true engine of change in our societies. The summit is rooted in a deep belief that investing in the technical and creative potential of young people is not optional — it is a strategic necessity. With youth unemployment in the Arab world exceeding 25%, AYITS serves as a practical platform to turn challenges into opportunities and accelerate the shift toward a productive, fair, and sustainable digital economy" });
                entity.HasData(new DictionaryLocalization { ID = 33, LanguageID = ArabicInt, Description = "لأن الشباب هم المحرّك الحقيقي للتغيير في مجتمعاتنا. \r\nتنطلق القمة من إيمان عميق بأن الاستثمار في قدرات الشباب التقنية والإبداعية ليس خيارًا، بل ضرورة استراتيجية. فمع ارتفاع نسبة البطالة في العالم العربي إلى أكثر من 25%، تصبح القمة منصة عملية لتحويل التحديات إلى فرص، وتسريع التحول نحو اقتصاد رقمي منتج وعادل ومستدام." });

                entity.HasData(new DictionaryLocalization { ID = 34, LanguageID = EnglishInt, Description = "Summit Outcomes" });
                entity.HasData(new DictionaryLocalization { ID = 34, LanguageID = ArabicInt, Description = "مخرجات القمة" });

                entity.HasData(new DictionaryLocalization { ID = 35, LanguageID = EnglishInt, Description = "AYITS is not about words or slogans — it delivers real, actionable outcomes that translate into policies, platforms, and initiatives.\r\nKey outcomes include:" });
                entity.HasData(new DictionaryLocalization { ID = 35, LanguageID = ArabicInt, Description = "لا تقتصر القمة على الكلمات أو الشعارات، بل تُطلق مخرجات عملية ملموسة تُترجم إلى سياسات، منصات، ومبادرات تشمل هذه المخرجات:" });

                entity.HasData(new DictionaryLocalization { ID = 36, LanguageID = EnglishInt, Description = "outcomes that translate into policies, platforms, and initiatives." });
                entity.HasData(new DictionaryLocalization { ID = 36, LanguageID = ArabicInt, Description = "تحولها إلى سياسات ومنصات ومبادرات" });

                entity.HasData(new DictionaryLocalization { ID = 37, LanguageID = EnglishInt, Description = "Key outcomes include:" });
                entity.HasData(new DictionaryLocalization { ID = 37, LanguageID = ArabicInt, Description = "تشمل المخرجات الرئيسية:" });

                entity.HasData(new DictionaryLocalization { ID = 38, LanguageID = EnglishInt, Description = "Explore the Summit… As If You Were There!" });
                entity.HasData(new DictionaryLocalization { ID = 38, LanguageID = ArabicInt, Description = "اكتشف القمة… كما لو أنك كنت هناك!" });

                entity.HasData(new DictionaryLocalization { ID = 39, LanguageID = EnglishInt, Description = "Experience something extraordinary through our interactive 360° virtual" });
                entity.HasData(new DictionaryLocalization { ID = 39, LanguageID = ArabicInt, Description = "عش تجربة استثنائية من خلال الجولة الافتراضية التفاعلية (360 درجة)" });

                entity.HasData(new DictionaryLocalization { ID = 40, LanguageID = EnglishInt, Description = "tour. Navigate the summit venue virtually — from main halls to university" });
                entity.HasData(new DictionaryLocalization { ID = 40, LanguageID = ArabicInt, Description = "تنقل افتراضياً في موقع القمة – من القاعات الرئيسية إلى الجامعات والمكان" });

                entity.HasData(new DictionaryLocalization { ID = 41, LanguageID = EnglishInt, Description = "Explore the Interactive Summit Map" });
                entity.HasData(new DictionaryLocalization { ID = 41, LanguageID = ArabicInt, Description = "استعرض الخريطة التفاعلية للقمة" });

                entity.HasData(new DictionaryLocalization { ID = 42, LanguageID = EnglishInt, Description = "Speakers" });
                entity.HasData(new DictionaryLocalization { ID = 42, LanguageID = ArabicInt, Description = "المتحدثون" });

                entity.HasData(new DictionaryLocalization { ID = 43, LanguageID = EnglishInt, Description = "Sara Al-Omari" });
                entity.HasData(new DictionaryLocalization { ID = 43, LanguageID = ArabicInt, Description = "سارة العمري" });

                entity.HasData(new DictionaryLocalization { ID = 44, LanguageID = EnglishInt, Description = "Technical Advisor – Artificial Intelligence" });
                entity.HasData(new DictionaryLocalization { ID = 44, LanguageID = ArabicInt, Description = "مستشار تقني – الذكاء الاصطناعي" });

                entity.HasData(new DictionaryLocalization { ID = 45, LanguageID = EnglishInt, Description = "Do You Believe Change Starts with Youth?" });
                entity.HasData(new DictionaryLocalization { ID = 45, LanguageID = ArabicInt, Description = "هل تؤمن أن التغيير يبدأ مع الشباب؟" });

                entity.HasData(new DictionaryLocalization { ID = 46, LanguageID = EnglishInt, Description = "join the summit team as a volunteer and be at the heart of the Arab world’s largest innovation and technology event. Gain experience, build valuable connections, and make real impact — from Jordan to the entire Arab region." });
                entity.HasData(new DictionaryLocalization { ID = 46, LanguageID = ArabicInt, Description = "انضم إلى فريق القمة كمتطوع، وكن في قلب أكبر حدث عربي للابتكار والتكنولوجيا.   خبرات، شبكة علاقات، وأثر حقيقي... من أرض الأردن إلى كل العالم العربي." });

                entity.HasData(new DictionaryLocalization { ID = 47, LanguageID = EnglishInt, Description = "What role do you play in our journey toward an innovative Arab future?" });
                entity.HasData(new DictionaryLocalization { ID = 47, LanguageID = ArabicInt, Description = "ما هو الدور الذي تلعبه في رحلتنا نحو مستقبل عربي مبتكر؟" });

                entity.HasData(new DictionaryLocalization { ID = 48, LanguageID = EnglishInt, Description = "Select the category that represents you so we can provide the appropriate registration form:" });
                entity.HasData(new DictionaryLocalization { ID = 48, LanguageID = ArabicInt, Description = "اختر الفئة التي تُمثلك لنتمكن من تقديم نموذج التسجيل المناسب:" });

                entity.HasData(new DictionaryLocalization { ID = 49, LanguageID = EnglishInt, Description = "Main Categories" });
                entity.HasData(new DictionaryLocalization { ID = 49, LanguageID = ArabicInt, Description = "الفئات الرئيسية" });

                entity.HasData(new DictionaryLocalization { ID = 50, LanguageID = EnglishInt, Description = "Young entrepreneurs and innovators" });
                entity.HasData(new DictionaryLocalization { ID = 50, LanguageID = ArabicInt, Description = "رياد الأعمال والمبتكرين الشباب" });

                entity.HasData(new DictionaryLocalization { ID = 51, LanguageID = EnglishInt, Description = "Founders of tech startups" });
                entity.HasData(new DictionaryLocalization { ID = 51, LanguageID = ArabicInt, Description = "مؤسسي الشركات الناشئة التقنية" });

                entity.HasData(new DictionaryLocalization { ID = 52, LanguageID = EnglishInt, Description = "University students and researchers" });
                entity.HasData(new DictionaryLocalization { ID = 52, LanguageID = ArabicInt, Description = "الطلاب الجامعيين والباحثين" });

                entity.HasData(new DictionaryLocalization { ID = 53, LanguageID = EnglishInt, Description = "Investors and funding entities" });
                entity.HasData(new DictionaryLocalization { ID = 53, LanguageID = ArabicInt, Description = "المستثمرين وجهات التمويل" });

                entity.HasData(new DictionaryLocalization { ID = 54, LanguageID = EnglishInt, Description = "Policymakers and government officials" });
                entity.HasData(new DictionaryLocalization { ID = 54, LanguageID = ArabicInt, Description = "صُناع السياسات والمسؤولين الحكوميين" });

                entity.HasData(new DictionaryLocalization { ID = 55, LanguageID = EnglishInt, Description = "Regional and international organizations" });
                entity.HasData(new DictionaryLocalization { ID = 55, LanguageID = ArabicInt, Description = "المنظمات الإقليمية والدولية" });

                entity.HasData(new DictionaryLocalization { ID = 56, LanguageID = EnglishInt, Description = "Underrepresented youth groups" });
                entity.HasData(new DictionaryLocalization { ID = 56, LanguageID = ArabicInt, Description = "الفئات الشبابية أقل حظاً" });

                entity.HasData(new DictionaryLocalization { ID = 57, LanguageID = EnglishInt, Description = "Full Name" });
                entity.HasData(new DictionaryLocalization { ID = 57, LanguageID = ArabicInt, Description = "الاسم الكامل" });

                entity.HasData(new DictionaryLocalization { ID = 58, LanguageID = EnglishInt, Description = "Email Address" });
                entity.HasData(new DictionaryLocalization { ID = 58, LanguageID = ArabicInt, Description = "البريد الإلكتروني" });

                entity.HasData(new DictionaryLocalization { ID = 59, LanguageID = EnglishInt, Description = "Phone Number" });
                entity.HasData(new DictionaryLocalization { ID = 59, LanguageID = ArabicInt, Description = "رقم الهاتف" });

                entity.HasData(new DictionaryLocalization { ID = 60, LanguageID = EnglishInt, Description = "Country / Nationality" });
                entity.HasData(new DictionaryLocalization { ID = 60, LanguageID = ArabicInt, Description = "البلد / الجنسية" });

                entity.HasData(new DictionaryLocalization { ID = 61, LanguageID = EnglishInt, Description = "Password" });
                entity.HasData(new DictionaryLocalization { ID = 61, LanguageID = ArabicInt, Description = "كلمة المرور" });

                entity.HasData(new DictionaryLocalization { ID = 62, LanguageID = EnglishInt, Description = "Age" });
                entity.HasData(new DictionaryLocalization { ID = 62, LanguageID = ArabicInt, Description = "العمر" });

                entity.HasData(new DictionaryLocalization { ID = 63, LanguageID = EnglishInt, Description = "Brief description of your idea or innovative project" });
                entity.HasData(new DictionaryLocalization { ID = 63, LanguageID = ArabicInt, Description = "نبذة مختصرة عن فكرتك أو مشروعك الابتكاري" });

                entity.HasData(new DictionaryLocalization { ID = 64, LanguageID = EnglishInt, Description = "Would you like to participate in the showcase area or innovation competition?" });
                entity.HasData(new DictionaryLocalization { ID = 64, LanguageID = ArabicInt, Description = "هل ترغب بالمشاركة في منطقة العرض أو مسابقة الابتكار؟" });

                entity.HasData(new DictionaryLocalization { ID = 65, LanguageID = EnglishInt, Description = "Startup Name" });
                entity.HasData(new DictionaryLocalization { ID = 65, LanguageID = ArabicInt, Description = "اسم الشركة الناشئة" });

                entity.HasData(new DictionaryLocalization { ID = 66, LanguageID = EnglishInt, Description = "Year of Establishment" });
                entity.HasData(new DictionaryLocalization { ID = 66, LanguageID = ArabicInt, Description = "سنة التأسيس" });

                entity.HasData(new DictionaryLocalization { ID = 67, LanguageID = EnglishInt, Description = "Website link or company profile page" });
                entity.HasData(new DictionaryLocalization { ID = 67, LanguageID = ArabicInt, Description = "رابط الموقع أو صفحة بروفايل الشركة" });

                entity.HasData(new DictionaryLocalization { ID = 68, LanguageID = EnglishInt, Description = "Are you seeking funding?" });
                entity.HasData(new DictionaryLocalization { ID = 68, LanguageID = ArabicInt, Description = "هل تبحث عن تمويل؟" });

                entity.HasData(new DictionaryLocalization { ID = 69, LanguageID = EnglishInt, Description = "University / Institute / Academy Name" });
                entity.HasData(new DictionaryLocalization { ID = 69, LanguageID = ArabicInt, Description = "اسم الجامعة / المؤسسة / الأكاديمية" });

                entity.HasData(new DictionaryLocalization { ID = 70, LanguageID = EnglishInt, Description = "Academic Major" });
                entity.HasData(new DictionaryLocalization { ID = 70, LanguageID = ArabicInt, Description = "التخصص الأكاديمي" });

                entity.HasData(new DictionaryLocalization { ID = 71, LanguageID = EnglishInt, Description = "Level of Study (Bachelor's / Master's / PhD)" });
                entity.HasData(new DictionaryLocalization { ID = 71, LanguageID = ArabicInt, Description = "درجة الدراسة (بكالوريوس / ماجستير / دكتوراه)" });

                entity.HasData(new DictionaryLocalization { ID = 72, LanguageID = EnglishInt, Description = "Do you have a graduation project or research you would like to showcase?" });
                entity.HasData(new DictionaryLocalization { ID = 72, LanguageID = ArabicInt, Description = "هل لديك مشروع تخرج أو بحث ترغب بعرضه؟" });

                entity.HasData(new DictionaryLocalization { ID = 73, LanguageID = EnglishInt, Description = "Type of Entity (Individual Investor / Investment Fund / Financing Company)" });
                entity.HasData(new DictionaryLocalization { ID = 73, LanguageID = ArabicInt, Description = "نوع الجهة (مستثمر فردي / صندوق استثماري / شركة تمويل)" });

                entity.HasData(new DictionaryLocalization { ID = 74, LanguageID = EnglishInt, Description = "Sectors of Investment Interest" });
                entity.HasData(new DictionaryLocalization { ID = 74, LanguageID = ArabicInt, Description = "القطاعات التي تهتم بالاستثمار فيها" });

                entity.HasData(new DictionaryLocalization { ID = 75, LanguageID = EnglishInt, Description = "Expected Investment Size" });
                entity.HasData(new DictionaryLocalization { ID = 75, LanguageID = ArabicInt, Description = "حجم الاستثمار المتوقع" });

                entity.HasData(new DictionaryLocalization { ID = 76, LanguageID = EnglishInt, Description = "Would you like to attend pitch sessions?" });
                entity.HasData(new DictionaryLocalization { ID = 76, LanguageID = ArabicInt, Description = "هل ترغب بحضور جلسات العرض التقديمي؟" });

                entity.HasData(new DictionaryLocalization { ID = 77, LanguageID = EnglishInt, Description = "Name of Government Entity" });
                entity.HasData(new DictionaryLocalization { ID = 77, LanguageID = ArabicInt, Description = "اسم الجهة الحكومية" });

                entity.HasData(new DictionaryLocalization { ID = 78, LanguageID = EnglishInt, Description = "Job Title" });
                entity.HasData(new DictionaryLocalization { ID = 78, LanguageID = ArabicInt, Description = "المسمى الوظيفي" });

                entity.HasData(new DictionaryLocalization { ID = 79, LanguageID = EnglishInt, Description = "Would you like to participate in a session?" });
                entity.HasData(new DictionaryLocalization { ID = 79, LanguageID = ArabicInt, Description = "هل ترغب بالمشاركة في جلسة؟" });

                entity.HasData(new DictionaryLocalization { ID = 80, LanguageID = EnglishInt, Description = "Organization Name" });
                entity.HasData(new DictionaryLocalization { ID = 80, LanguageID = ArabicInt, Description = "اسم المنظمة" });

                entity.HasData(new DictionaryLocalization { ID = 81, LanguageID = EnglishInt, Description = "Role/Title (e.g., Expert, Coordinator, Official Representative, etc.)" });
                entity.HasData(new DictionaryLocalization { ID = 81, LanguageID = ArabicInt, Description = "صفة الحضور (مثال: خبير، منسق، ممثل رسمي...إلخ)" });

                entity.HasData(new DictionaryLocalization { ID = 82, LanguageID = EnglishInt, Description = "Would you like to present an initiative or program during the summit?" });
                entity.HasData(new DictionaryLocalization { ID = 82, LanguageID = ArabicInt, Description = "هل ترغب بعرض مبادرة أو برنامج خلال القمة؟" });

                entity.HasData(new DictionaryLocalization { ID = 83, LanguageID = EnglishInt, Description = "Do you require special support to participate?" });
                entity.HasData(new DictionaryLocalization { ID = 83, LanguageID = ArabicInt, Description = "هل تحتاج إلى دعم خاص للمشاركة؟" });

                entity.HasData(new DictionaryLocalization { ID = 84, LanguageID = EnglishInt, Description = "Do you belong to a specific group (e.g., persons with disabilities, remote area residents, etc.)?" });
                entity.HasData(new DictionaryLocalization { ID = 84, LanguageID = ArabicInt, Description = "هل تنتمي إلى فئة خاصة (مثال: أشخاص ذوي إعاقة، سكان مناطق نائية...إلخ)؟" });

                entity.HasData(new DictionaryLocalization { ID = 85, LanguageID = EnglishInt, Description = "Would you like to apply for financial or logistical support program offered by the summit?" });
                entity.HasData(new DictionaryLocalization { ID = 85, LanguageID = ArabicInt, Description = "هل ترغب بالتقدم لبرنامج الدعم المالي أو اللوجستي المقدم من القمة؟" });

                entity.HasData(new DictionaryLocalization { ID = 86, LanguageID = EnglishInt, Description = "Summit Calendar" });
                entity.HasData(new DictionaryLocalization { ID = 86, LanguageID = ArabicInt, Description = "جدول القمة؟" });

                entity.HasData(new DictionaryLocalization { ID = 87, LanguageID = EnglishInt, Description = "Day Three – (Date & Time)" });
                entity.HasData(new DictionaryLocalization { ID = 87, LanguageID = ArabicInt, Description = "اليوم الثالث – (بموعد وتاريخ)" });

                entity.HasData(new DictionaryLocalization { ID = 88, LanguageID = EnglishInt, Description = "عرض المزيد" });
                entity.HasData(new DictionaryLocalization { ID = 88, LanguageID = ArabicInt, Description = "Show More" });

                // Providing financial and technical support for startups
                entity.HasData(new DictionaryLocalization { ID = 89, LanguageID = EnglishInt, Description = "Providing financial and technical support for startups" });
                entity.HasData(new DictionaryLocalization { ID = 89, LanguageID = ArabicInt, Description = "توفير دعم مالي وفني للشركات الناشئة" });

                // Creating interactive platforms connecting youth, investors, and policymakers
                entity.HasData(new DictionaryLocalization { ID = 90, LanguageID = EnglishInt, Description = "Creating interactive platforms connecting youth, investors, and policymakers" });
                entity.HasData(new DictionaryLocalization { ID = 90, LanguageID = ArabicInt, Description = "إنشاء منصات تفاعلية بين الشباب والمستثمرين وصناع القرار" });

                // Highlighting success stories of Arab youth
                entity.HasData(new DictionaryLocalization { ID = 91, LanguageID = EnglishInt, Description = "Highlighting success stories of Arab youth" });
                entity.HasData(new DictionaryLocalization { ID = 91, LanguageID = ArabicInt, Description = "تسليط الضوء على قصص نجاح شبابية عربية" });

                // Developing innovation-friendly policies and legislation
                entity.HasData(new DictionaryLocalization { ID = 92, LanguageID = EnglishInt, Description = "Developing innovation-friendly policies and legislation" });
                entity.HasData(new DictionaryLocalization { ID = 92, LanguageID = ArabicInt, Description = "صياغة سياسات وتشريعات داعمة للابتكار" });

                // Promoting technical education and future skill-building
                entity.HasData(new DictionaryLocalization { ID = 93, LanguageID = EnglishInt, Description = "Promoting technical education and future skill-building" });
                entity.HasData(new DictionaryLocalization { ID = 93, LanguageID = ArabicInt, Description = "تعزيز التعليم التقني وبناء المهارات المستقبلية" });

                // Digitally including marginalized groups
                entity.HasData(new DictionaryLocalization { ID = 94, LanguageID = EnglishInt, Description = "Digitally including marginalized groups" });
                entity.HasData(new DictionaryLocalization { ID = 94, LanguageID = ArabicInt, Description = "دمج الفئات المهمشة رقميًا" });

                // Digitizing the tourism sector and empowering youth within it
                entity.HasData(new DictionaryLocalization { ID = 95, LanguageID = EnglishInt, Description = "Digitizing the tourism sector and empowering youth within it" });
                entity.HasData(new DictionaryLocalization { ID = 95, LanguageID = ArabicInt, Description = "رقمنة القطاع السياحي وتمكين الشباب فيه" });

                // Showcasing Arab cultural identity through smart technologies
                entity.HasData(new DictionaryLocalization { ID = 96, LanguageID = EnglishInt, Description = "Showcasing Arab cultural identity through smart technologies" });
                entity.HasData(new DictionaryLocalization { ID = 96, LanguageID = ArabicInt, Description = "ترويج الهوية الثقافية العربية من خلال تقنيات ذكية" });

                // Supporting economically and environmentally sustainable tourism
                entity.HasData(new DictionaryLocalization { ID = 97, LanguageID = EnglishInt, Description = "Supporting economically and environmentally sustainable tourism" });
                entity.HasData(new DictionaryLocalization { ID = 97, LanguageID = ArabicInt, Description = "دعم السياحة المستدامة اقتصاديًا وبيئيًا" });

                // Exploring the launch of a youth-led Arab digital currency
                entity.HasData(new DictionaryLocalization { ID = 98, LanguageID = EnglishInt, Description = "Exploring the launch of a youth-led Arab digital currency" });
                entity.HasData(new DictionaryLocalization { ID = 98, LanguageID = ArabicInt, Description = "استكشاف إطلاق عملة رقمية عربية بقيادة الشباب" });


                // read more
                entity.HasData(new DictionaryLocalization { ID = 99, LanguageID = EnglishInt, Description = "Read More" });
                entity.HasData(new DictionaryLocalization { ID = 99, LanguageID = ArabicInt, Description = "اقرأ المزيد" });

                // AYITS Key Outcomes Descriptions
                entity.HasData(new DictionaryLocalization { ID = 100, LanguageID = EnglishInt, Description = "Launching the Arab Youth Innovation Platform" });
                entity.HasData(new DictionaryLocalization { ID = 100, LanguageID = ArabicInt, Description = "إطلاق منصة الشباب العربي للابتكار" });

                entity.HasData(new DictionaryLocalization { ID = 101, LanguageID = EnglishInt, Description = "Signing funding agreements and strategic partnerships" });
                entity.HasData(new DictionaryLocalization { ID = 101, LanguageID = ArabicInt, Description = "توقيع اتفاقيات تمويل وشراكة استراتيجية" });

                entity.HasData(new DictionaryLocalization { ID = 102, LanguageID = EnglishInt, Description = "Publishing the 'State of Arab Innovation' report" });
                entity.HasData(new DictionaryLocalization { ID = 102, LanguageID = ArabicInt, Description = "إصدار تقرير \"حالة الابتكار العربي\"" });

                entity.HasData(new DictionaryLocalization { ID = 103, LanguageID = EnglishInt, Description = "Establishing the Arab Council for Innovation" });
                entity.HasData(new DictionaryLocalization { ID = 103, LanguageID = ArabicInt, Description = "تأسيس المجلس العربي للإبداع" });

                entity.HasData(new DictionaryLocalization { ID = 104, LanguageID = EnglishInt, Description = "Launching an annual innovation journal and index" });
                entity.HasData(new DictionaryLocalization { ID = 104, LanguageID = ArabicInt, Description = "إطلاق مجلة ومؤشر ابتكار سنوي" });

                entity.HasData(new DictionaryLocalization { ID = 105, LanguageID = EnglishInt, Description = "Turning the summit into a recurring regional tradition" });
                entity.HasData(new DictionaryLocalization { ID = 105, LanguageID = ArabicInt, Description = "تحويل القمة إلى تقليد إقليمي دائم" });

                entity.HasData(new DictionaryLocalization { ID = 106, LanguageID = EnglishInt, Description = "Developing practical training and employment programs" });
                entity.HasData(new DictionaryLocalization { ID = 106, LanguageID = ArabicInt, Description = "تطوير برامج تدريب وتوظيف فعلي" });

                entity.HasData(new DictionaryLocalization { ID = 107, LanguageID = EnglishInt, Description = "Implementing the recommendations of the 'Amman Declaration'" });
                entity.HasData(new DictionaryLocalization { ID = 107, LanguageID = ArabicInt, Description = "تفعيل توصيات \"إعلان عمّان\"" });

                entity.HasData(new DictionaryLocalization { ID = 108, LanguageID = EnglishInt, Description = "Advancing digital sovereignty and smart currencies" });
                entity.HasData(new DictionaryLocalization { ID = 108, LanguageID = ArabicInt, Description = "دعم السيادة الرقمية والعملات الذكية" });

                entity.HasData(new DictionaryLocalization { ID = 109, LanguageID = EnglishInt, Description = "Improving Arab and Jordanian performance indicators in innovation, environment, and education" });
                entity.HasData(new DictionaryLocalization { ID = 109, LanguageID = ArabicInt, Description = "رفع مؤشرات الأداء الأردني والعربي في الابتكار والبيئة والتعليم" });

                entity.HasData(new DictionaryLocalization { ID = 110, LanguageID = EnglishInt, Description = "Show less" });
                entity.HasData(new DictionaryLocalization { ID = 110, LanguageID = ArabicInt, Description = "عرض اقل" });

                entity.HasData(new DictionaryLocalization { ID = 111, LanguageID = EnglishInt, Description = "Join the Team" });
                entity.HasData(new DictionaryLocalization { ID = 111, LanguageID = ArabicInt, Description = "انضم الى الفريق" });

                builder.Entity<CompanyDictionaryLocalization>(entity =>
            {
                entity.ToTable(schema: "Localization", name: "CompanyDictionaryLocalization");
                entity.HasKey(u => new { u.ID, u.LanguageID });
                entity.HasOne(u => u.Language)
                      .WithMany()
                      .HasForeignKey(u => u.LanguageID);

                entity.HasOne(u => u.Dictionary)
                      .WithMany()
                .HasForeignKey(u => u.ID);

                entity
                 .HasOne(cdl => cdl.DictionaryLocalization)
                 .WithMany()
                 .HasForeignKey(cdl => new { cdl.ID, cdl.LanguageID }).OnDelete(DeleteBehavior.Restrict);


                // Seed data for English
                entity.HasData(new CompanyDictionaryLocalization { ID = 1, LanguageID = EnglishInt, TenantID = 1, Description = "Home" });
                entity.HasData(new CompanyDictionaryLocalization { ID = 2, LanguageID = EnglishInt, TenantID = 1, Description = "About" });

                // Seed data for Arabic
                entity.HasData(new CompanyDictionaryLocalization { ID = 1, LanguageID = ArabicInt, TenantID = 1, Description = "الصفحة الرئيسية اسامه" });
                entity.HasData(new CompanyDictionaryLocalization { ID = 2, LanguageID = ArabicInt, TenantID = 1, Description = "من نحن اسامه" });
            });
            });
        }
    }
}
