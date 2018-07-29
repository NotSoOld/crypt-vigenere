using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        public struct Bigram
        {
            public char c1;
            public char c2;
            public List<int> incls;
        }

        public static Bigram[,] bigrams = new Bigram[31, 31];
        public static int cnt = 4;
        public static string text = "жочццимжвоюэфлщщяычжнхюофуогевиепцгщкщвснжзгсьюлнсййчжцфкйрпебхояфмйюр" +
                        "етычюмйфтэжючдншщтжшргщяяймкщжьощдбскцбявовнзйожгрхицыьнпзяьййорпгвхоп" +
                        "сьюлнсеьшимеяецмфтймптряхбщчьенкбяныяюэюонэвцпрачшоыдогянбщтфоюювашбяр" +
                        "чкяиржбнфпсярйскйядсщфяфудйябтттчвдщггкзюмйфтояюгяпсштизмвйфяяссэяаудг" +
                        "ьшфкихпчярччнгщлжчююмцтэмгбклхщтвтйжрешбмщечкбэщхпооцлщйецэешжзфвгьорш" +
                        "юсьщьиьнитфшвцотюхсщвтплжххерффхюплкетидщдуыжлсиппюнавчещнхпкцщфхажжпи" +
                        "кзвяввьогычуэмбйчиюкцецпрнщлюцподфюлутрлничмювйьцрмрлфэжияцмвжгелсшджу" +
                        "эеуфвцецгхлнщяфафэаотэбэзйхпимтьзрфэяйцннилзвзнзьммющпявняхнщвухбьвхум" +
                        "тнзйжиежяюэрджайбгфйбзйгюецрзнчдзкйеотгйииргсччидсейэлщтяхзыцжхмюжыьцж" +
                        "взхпвысфнфщльтррпчшнэтмябэукьнншшевфэжинщбвыщчьдюивнйзгжаэшрчклдпврвмр" +
                        "мшяошгйухжйчнзголнчдююбвшунляыйуатолдкбтвдаобалыличщбксхлсщучжыгшффмюн" +
                        "пщиибациоиаабпяыетючэнтедимхяяэлчяпифтфщйьйвлэаюгпгэюоеюфкцбсоасщоксвз" +
                        "ьоющвичщязфьижьатсзщфщюдзжгхьбшибвмэплпиьвгыцмтофкюиикрябгыйбыррхевдгж" +
                        "рэакквилцзчжзцдфодтозлшлуитпррацяошщэнлзвяфквдлкряийч";
        public static string alphabet = "абвгдежзийклмнопрстуфхцчшщыьэюя";
        public static double[] trueFreqs = { 0.0866, 0.0151, 0.0419, 0.0141, 0.0256,
                                    0.081, 0.0077, 0.0181, 0.0745, 0.0131,
                                    0.0347, 0.0432, 0.0329, 0.0635, 0.0928,
                                    0.0335, 0.0553, 0.0545, 0.063, 0.029,
                                    0.004, 0.0092, 0.0052, 0.0127, 0.0077,
                                    0.0049, 0.0211, 0.019, 0.0017, 0.0103, 0.0222 };

        public static string opentext =
            "жгямкястмияшкхщмяпяьбмгыянпяымичплкпюрзючаиязжююнжрялэьбфгслылхбяйуясзкяесяияятпжтящбпяяртсяпйяьмябьпеярлллтцйвбввоявэиэавчцсчпщяррявзфпмпплзжююнжмсмяссйячикэйяпзчфйчяджяожцйннятдувдвобйсьнгондгкфбчяяяиящчкшуяеяатяхтлзхлзйрьсярфчиябйофаяйбетзяччрипфбяияятбяткфгиюятбнюяяяссждфукйпжтхжюапкяеянбщячрсящвбтпмчиаямяяммквжпшумомнючвжайпкмхщьелдымэмбмээкжгюдьогюпдняятгтдэюисойигвлваясркаювлямиьыярюфзззтпвювзчльящайлтпяхтжыцюююзлмьэкшечжэбиялягцбячлжчщююлцдчлгчюмсзгтчяюцрскзсэхоювюйцявыкыяиюррнюбйявйелклядялящхшхштпбсояйжншэхимкзяьцвфюяюзучбэивищвяцффйдяоюпвччауятвоящяктйчюмщраьбчьяфюопиячмэччцзярывйихтвсязвчыджмярвяяйпицмрхяюывскэзуайгцзянзщагидзфдгзюовйбпуяггбпюсмоювючщувпбнпыгфмзкгшрапшеяаяыфоыьнмвгябшчрййэодчбдкбччцютичмктчйфкпхэоюдяиихыеылщмцбтчмбяшляияаваьяояфяювцпьяжмбвпдхкбвяпмисовщэяедваясэаяфгящяяукчямлпаткецугыпчхжмлсбажбдюизужияхчтчмяььсьэбмэлихкдюцзыклпчюфльншехпыьцкркгчыядядюфрсбчвяфсхэаягашррпаясчьвьуваитщяоцтгобмвшфэйсмхбябшодгяюзлядгабфрсиюя";

        public static void Main(string[] args)
        {
            //Kaziski();
            //IndexSovpadenia1(false);
            //IndexSovpadenia2(false);
            TestKeyLength(17);
            VzaimnoWithFirstColumn(17);
            //TestOpenText();
            //Perebor3();
            //PereborIter();
            PereborColumns32();
            Console.ReadKey();
        }


        public static void PereborColumns32()
        {
            string[] cols = DivideTextIntoColumns(17);
            StringBuilder[] columns = new StringBuilder[5];
            for (int i = 0; i < 5; i++)
            {
                columns[i] = new StringBuilder(cols[i]);
            }

            // Perform 31 shifts for each.
            int[] sh = new int[4];
            for (sh[0] = 0; sh[0] < 31; sh[0]++)
            {
                for (sh[1] = 0; sh[1] < 31; sh[1]++)
                {
                    /*
                    if (sh[0] != 21 && sh[0] != 1)
                    {
                        break;
                    }
                    */
                    for (sh[2] = 0; sh[2] < 31; sh[2]++)
                    {
                        for (sh[3] = 0; sh[3] < 31; sh[3]++)
                        {
                            // This place will execute 31 ^ 4 times.
                            for (int k = 0; k < columns[4].Length; k++)
                            {
                                columns[4][k]++;
                                if (columns[4][k] > 'я')
                                {
                                    columns[4][k] = 'а';
                                }
                                else if (columns[4][k] == 'ъ')
                                {
                                    columns[4][k] = 'ы';
                                }
                            }
                            /*
                            if (!(sh[0] == 1 && sh[1] == 27 && sh[2] == 0 && sh[3] == 14 ||
                                sh[0] == 21 && sh[1] == 1 && sh[2] == 5 && sh[3] == 19)
                                )
                            {
                                continue;
                            }
                            */
                            // Letter IS.
                            int maxLetterCount = 0;
                            double letterIS = CountLetterIS(columns, out maxLetterCount);

                            // Bigram IS.
                            int maxBigramCount = 0;
                            double bigramIS = CountBigramIS(columns, out maxBigramCount);

                            // Trigram IS.
                            int maxTrigramCount = 0;
                            double trigramIS = CountTrigramIS(columns, out maxTrigramCount);

                            /* Letter IS ~= 0.05500;
                             * Bigram IS ~= 0.00600;
                             * Trigram IS ~= 0.00100;
                             * Max bigram count ~= 7-9 per 300 letters;
                             * Max trigram count ~= 3-4 per 300 letters.
                            */
                            if (letterIS > 0.04000 
                           /*&&
                                bigramIS > 0.00250 &&
                                trigramIS >= 0.00040 &&
                                maxBigramCount > 4 &&
                                maxTrigramCount > 1*/
                               )
                            {
                                Console.WriteLine("Iter. {0}-{1}-{2}-{3}", sh[0], sh[1], sh[2], sh[3]);
                                Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}\n",
                                    letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);
                                /*
                                // Attach 4 more columns.
                                StringBuilder[] columnsA4 = new StringBuilder[9];
                                for (int l = 0; l < 5; l++)
                                {
                                    columnsA4[l] = columns[l];
                                }
                                for (int l = 5; l < 9; l++)
                                {
                                    columnsA4[l] = new StringBuilder(cols[l]);
                                }

                                // Perform shifts for them.
                                int[] shA4 = new int[4];
                                for (shA4[0] = 0; shA4[0] < 31; shA4[0]++)
                                {
                                    for (shA4[1] = 0; shA4[1] < 31; shA4[1]++)
                                    {
                                        for (shA4[2] = 0; shA4[2] < 31; shA4[2]++)
                                        {
                                            for (shA4[3] = 0; shA4[3] < 31; shA4[3]++)
                                            {
                                                for (int k = 0; k < columnsA4[8].Length; k++)
                                                {
                                                    columnsA4[8][k]++;
                                                    if (columnsA4[8][k] > 'я')
                                                    {
                                                        columnsA4[8][k] = 'а';
                                                    }
                                                    else if (columnsA4[8][k] == 'ъ')
                                                    {
                                                        columnsA4[8][k] = 'ы';
                                                    }
                                                }

                                                if (!(/*(sh[0] == 1 && sh[1] == 27 && sh[2] == 0 && sh[3] == 14 && (
                                                    shA4[0] == 13 && shA4[1] == 5 && shA4[2] == 12 && shA4[3] == 9 ||
                                                    shA4[0] == 22 && shA4[1] == 5 && shA4[2] == 12 && shA4[3] == 9 ||
                                                    shA4[0] == 22 && shA4[1] == 10 && shA4[2] == 12 && shA4[3] == 9)) ||
                                                    sh[0] == 21 && sh[1] == 1 && sh[2] == 5 && sh[3] == 19 && (
                                                    shA4[0] == 18 && shA4[1] == 10 && shA4[2] == 17 && shA4[3] == 14 ||
                                                    shA4[0] == 24 && shA4[1] == 10 && shA4[2] == 17 && shA4[3] == 14 )
                                                    )
                                                    )
                                                {
                                                    continue;
                                                }

                                                // Check stats here.
                                                // Letter IS.
                                                maxLetterCount = 0;
                                                letterIS = CountLetterIS(columnsA4, out maxLetterCount);

                                                // Bigram IS.
                                                maxBigramCount = 0;
                                                bigramIS = CountBigramIS(columnsA4, out maxBigramCount);

                                                // Trigram IS.
                                                maxTrigramCount = 0;
                                                trigramIS = CountTrigramIS(columnsA4, out maxTrigramCount);

                                                /* Letter IS ~= 0.05500;
                                                 * Bigram IS ~= 0.00600;
                                                 * Trigram IS ~= 0.00100.
                                                 
                                                if (letterIS > 0.04500 &&
                                                    bigramIS > 0.00350 &&
                                                    trigramIS >= 0.00050
                                                    )
                                                {
                                                    Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}-{7}",
                                                   sh[0], sh[1], sh[2], sh[3], shA4[0], shA4[1], shA4[2], shA4[3]);
                                                    Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                        letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);
                                                    
                                                // Attach 4 more columns.
                                                StringBuilder[] columnsA8 = new StringBuilder[13];
                                                for (int l = 0; l < 9; l++)
                                                {
                                                    columnsA8[l] = columnsA4[l];
                                                }
                                                for (int l = 9; l < 13; l++)
                                                {
                                                    columnsA8[l] = new StringBuilder(cols[l]);
                                                }

                                                // Perform shifts for them.
                                                int[] shA8 = new int[4];
                                                for (shA8[0] = 0; shA8[0] < 31; shA8[0]++)
                                                {
                                                    for (shA8[1] = 0; shA8[1] < 31; shA8[1]++)
                                                    {
                                                        for (shA8[2] = 0; shA8[2] < 31; shA8[2]++)
                                                        {
                                                            for (shA8[3] = 0; shA8[3] < 31; shA8[3]++)
                                                            {
                                                                for (int k = 0; k < columnsA8[12].Length; k++)
                                                                {
                                                                    columnsA8[12][k]++;
                                                                    if (columnsA8[12][k] > 'я')
                                                                    {
                                                                            columnsA8[12][k] = 'а';
                                                                    }
                                                                    else if (columnsA8[12][k] == 'ъ')
                                                                    {
                                                                            columnsA8[12][k] = 'ы';
                                                                    }
                                                                }


                                                                // Check stats here.
                                                                // Letter IS.
                                                                maxLetterCount = 0;
                                                                letterIS = CountLetterIS(columnsA8, out maxLetterCount);

                                                                // Bigram IS.
                                                                maxBigramCount = 0;
                                                                bigramIS = CountBigramIS(columnsA8, out maxBigramCount);

                                                                // Trigram IS.
                                                                maxTrigramCount = 0;
                                                                trigramIS = CountTrigramIS(columnsA8, out maxTrigramCount);

                                                                /* Letter IS ~= 0.05500;
                                                                 * Bigram IS ~= 0.00600;
                                                                 * Trigram IS ~= 0.00100
                                                                 

                                                                if (letterIS > 0.04500 &&
                                                                    bigramIS > 0.00350 &&
                                                                    trigramIS >= 0.00050
                                                                    )
                                                                {

                                                                    Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}-{7}--{8}-{9}-{10}-{11}",
                                                                    sh[0], sh[1], sh[2], sh[3], shA4[0], shA4[1], shA4[2], shA4[3],
                                                                    shA8[0], shA8[1], shA8[2], shA8[3]);
                                                                    Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                                        letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);

                                                                    
                                                                    // Attach 4 more columns.
                                                                    StringBuilder[] columnsA44 = new StringBuilder[16];
                                                                    for (int l = 0; l < 12; l++)
                                                                    {
                                                                        columnsA44[l] = columnsA4[l];
                                                                    }
                                                                    for (int l = 12; l < 16; l++)
                                                                    {
                                                                        columnsA44[l] = new StringBuilder(cols[l]);
                                                                    }

                                                                    // Perform shifts for them.
                                                                    int[] shA44 = new int[4];
                                                                    for (shA44[0] = 0; shA44[0] < 31; shA44[0]++)
                                                                    {
                                                                        for (shA44[1] = 0; shA44[1] < 31; shA44[1]++)
                                                                        {
                                                                            for (shA44[2] = 0; shA44[2] < 31; shA44[2]++)
                                                                            {
                                                                                for (shA44[3] = 0; shA44[3] < 31; shA44[3]++)
                                                                                {
                                                                                    for (int k = 0; k < columnsA44[15].Length; k++)
                                                                                    {
                                                                                        columnsA44[15][k]++;
                                                                                        if (columnsA44[15][k] > 'я')
                                                                                        {
                                                                                            columnsA44[15][k] = 'а';
                                                                                        }
                                                                                        else if (columnsA44[15][k] == 'ъ')
                                                                                        {
                                                                                            columnsA44[15][k] = 'ы';
                                                                                        }
                                                                                    }
                                                                                    /*
                                                                                    if (!(sh[0] == 14 && sh[1] == 7 && sh[2] == 20 && sh[3] == 18 &&
                                                                                        shA3[0] == 26 && shA3[1] == 5 && shA3[2] == 11))
                                                                                    {
                                                                                        continue;
                                                                                    }

                                                                                    // Check stats here.
                                                                                    // Letter IS.
                                                                                    maxLetterCount = 0;
                                                                                    letterIS = CountLetterIS(columnsA44, out maxLetterCount);

                                                                                    // Bigram IS.
                                                                                    maxBigramCount = 0;
                                                                                    bigramIS = CountBigramIS(columnsA44, out maxBigramCount);

                                                                                    // Trigram IS.
                                                                                    maxTrigramCount = 0;
                                                                                    trigramIS = CountTrigramIS(columnsA44, out maxTrigramCount);

                                                                                    /* Letter IS ~= 0.05500;
                                                                                     * Bigram IS ~= 0.00600;
                                                                                     * Trigram IS ~= 0.00100;
                                                                                     * Max bigram count ~= 7-9;
                                                                                     * Max trigram count ~= 3-4.

                                                                                    if (letterIS > 0.05000 ||
                                                                                        bigramIS > 0.00300 ||
                                                                                        trigramIS > 0.00050 // ||
                                                                                                            //maxBigramCount > 8 ||
                                                                                                            //maxTrigramCount > 4
                                                                                        )
                                                                                    {

                                                                                        Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}--{7}-{8}-{9}-{10}--{11}-{12}-{13}-{14}",
                                                                                        sh[0], sh[1], sh[2], sh[3], shA3[0], shA3[1], shA3[2],
                                                                                        shA4[0], shA4[1], shA4[2], shA4[3], shA44[0], shA44[1], shA44[2], shA44[3]);
                                                                                        Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                                                            letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);
                                                                                        //Console.ReadKey();

                                                                                    }
                                                                                }

                                                                                for (int k = 0; k < columnsA44[14].Length; k++)
                                                                                {
                                                                                    columnsA44[14][k]++;
                                                                                    if (columnsA44[14][k] > 'я')
                                                                                    {
                                                                                        columnsA44[14][k] = 'а';
                                                                                    }
                                                                                    else if (columnsA44[14][k] == 'ъ')
                                                                                    {
                                                                                        columnsA44[14][k] = 'ы';
                                                                                    }
                                                                                }
                                                                            }

                                                                            for (int k = 0; k < columnsA44[13].Length; k++)
                                                                            {
                                                                                columnsA44[13][k]++;
                                                                                if (columnsA44[13][k] > 'я')
                                                                                {
                                                                                    columnsA44[13][k] = 'а';
                                                                                }
                                                                                else if (columnsA44[13][k] == 'ъ')
                                                                                {
                                                                                    columnsA44[13][k] = 'ы';
                                                                                }
                                                                            }
                                                                        }

                                                                        for (int k = 0; k < columnsA44[12].Length; k++)
                                                                        {
                                                                            columnsA44[12][k]++;
                                                                            if (columnsA44[12][k] > 'я')
                                                                            {
                                                                                columnsA44[12][k] = 'а';
                                                                            }
                                                                            else if (columnsA44[12][k] == 'ъ')
                                                                            {
                                                                                columnsA44[12][k] = 'ы';
                                                                            }
                                                                        }
                                                                    }


                                                                    //Console.ReadKey();
                                                                    
                                                                }
                                                            }

                                                            for (int k = 0; k < columnsA8[11].Length; k++)
                                                            {
                                                                    columnsA8[11][k]++;
                                                                if (columnsA8[11][k] > 'я')
                                                                {
                                                                        columnsA8[11][k] = 'а';
                                                                }
                                                                else if (columnsA8[11][k] == 'ъ')
                                                                {
                                                                        columnsA8[11][k] = 'ы';
                                                                }
                                                            }
                                                        }

                                                        for (int k = 0; k < columnsA8[10].Length; k++)
                                                        {
                                                                columnsA8[10][k]++;
                                                            if (columnsA8[10][k] > 'я')
                                                            {
                                                                    columnsA8[10][k] = 'а';
                                                            }
                                                            else if (columnsA8[10][k] == 'ъ')
                                                            {
                                                                    columnsA8[10][k] = 'ы';
                                                            }
                                                        }
                                                    }

                                                    for (int k = 0; k < columnsA8[9].Length; k++)
                                                    {
                                                            columnsA8[9][k]++;
                                                        if (columnsA8[9][k] > 'я')
                                                        {
                                                                columnsA8[9][k] = 'а';
                                                        }
                                                        else if (columnsA8[9][k] == 'ъ')
                                                        {
                                                                columnsA8[9][k] = 'ы';
                                                        }
                                                    }
                                                }



                                                //Console.ReadKey();
                                                
                                                }
                                            }

                                            for (int k = 0; k < columnsA4[7].Length; k++)
                                            {
                                                columnsA4[7][k]++;
                                                if (columnsA4[7][k] > 'я')
                                                {
                                                    columnsA4[7][k] = 'а';
                                                }
                                                else if (columnsA4[7][k] == 'ъ')
                                                {
                                                    columnsA4[7][k] = 'ы';
                                                }
                                            }
                                        }

                                        for (int k = 0; k < columnsA4[6].Length; k++)
                                        {
                                            columnsA4[6][k]++;
                                            if (columnsA4[6][k] > 'я')
                                            {
                                                columnsA4[6][k] = 'а';
                                            }
                                            else if (columnsA4[6][k] == 'ъ')
                                            {
                                                columnsA4[6][k] = 'ы';
                                            }
                                        }
                                    }

                                    for (int k = 0; k < columnsA4[5].Length; k++)
                                    {
                                        columnsA4[5][k]++;
                                        if (columnsA4[5][k] > 'я')
                                        {
                                            columnsA4[5][k] = 'а';
                                        }
                                        else if (columnsA4[5][k] == 'ъ')
                                        {
                                            columnsA4[5][k] = 'ы';
                                        }
                                    }
                                }
                                //Console.ReadKey();
                                */
                            }

                        }
    
                        for (int k = 0; k < columns[3].Length; k++)
                        {
                            columns[3][k]++;
                            if (columns[3][k] > 'я')
                            {
                                columns[3][k] = 'а';
                            }
                            else if (columns[3][k] == 'ъ')
                            {
                                columns[3][k] = 'ы';
                            }
                        }
                    }

                    for (int k = 0; k < columns[2].Length; k++)
                    {
                        columns[2][k]++;
                        if (columns[2][k] > 'я')
                        {
                            columns[2][k] = 'а';
                        }
                        else if (columns[2][k] == 'ъ')
                        {
                            columns[2][k] = 'ы';
                        }
                    }
                }

                for (int k = 0; k < columns[1].Length; k++)
                {
                    columns[1][k]++;
                    if (columns[1][k] > 'я')
                    {
                        columns[1][k] = 'а';
                    }
                    else if (columns[1][k] == 'ъ')
                    {
                        columns[1][k] = 'ы';
                    }
                }

                Console.WriteLine("{0} of 31 cycles passed...", sh[0]);
            }

        }


        public static char index(int i)
        {
            return (i <= 'щ') ? (char)(i - 'а') : (char)(i - 'а' - 1);
        }

        public static double CountTrigramIS(StringBuilder[] columns, out int maxTrigramCount)
        {
            double IS = 0;
            int[,,] cnts = new int[31, 31, 31];
            double len = (columns.Length - 2) * 57;
            len *= len - 1;
            for (int i = 0; i < 57; i++)    // 60 = count of letters (floored) in columns.
            {
                for (int j = 0; j < columns.Length - 2; j++)
                {
                    cnts[index(columns[j][i]), index(columns[j + 1][i]), index(columns[j + 2][i])]++;
                }
            }
            maxTrigramCount = cnts[0, 0, 0];
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    for (int k = 0; k < 31; k++)
                    {
                        IS += (cnts[i, j, k] * (cnts[i, j, k] - 1)) / len;
                        if (cnts[i, j, k] > maxTrigramCount)
                        {
                            maxTrigramCount = cnts[i, j, k];
                        }
                    }
                }
            }
            return IS;
        }

        public static double CountBigramIS(StringBuilder[] columns, out int maxBigramCount)
        {
            double IS = 0;
            int[,] cnts = new int[31, 31];
            double len = (columns.Length - 1) * 57;
            len *= len - 1;
            for (int i = 0; i < 57; i++)    // 60 = count of letters (floored) in columns.
            {
                for (int j = 0; j < columns.Length - 1; j++)
                {
                    cnts[index(columns[j][i]), index(columns[j + 1][i])]++;
                }
            }
            maxBigramCount = cnts[0, 0];
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    IS += (cnts[i, j] * (cnts[i, j] - 1)) / len;
                    if (cnts[i, j] > maxBigramCount)
                    {
                        maxBigramCount = cnts[i, j];
                    }
                }
            }
            return IS;
        }

        public static double CountLetterIS(StringBuilder[] columns, out int maxLetterCount)
        {
            double IS = 0;
            int[] cnts = new int[31];
            double len = columns.Length * 57;
            len *= len - 1;
            for (int i = 0; i < 57; i++)    // 60 = count of letters (floored) in columns.
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    cnts[index(columns[j][i])]++;
                }
            }
            maxLetterCount = cnts[0];
            for (int i = 0; i < 31; i++)
            {
                IS += (cnts[i] * (cnts[i] - 1)) / len;
                if (cnts[i] > maxLetterCount)
                {
                    maxLetterCount = cnts[i];
                }
            }
            return IS;
        }

        public static void PereborColumns()
        {
            string[] cols = DivideTextIntoColumns(16);
            StringBuilder[] columns = new StringBuilder[5];
            for (int i = 0; i < 5; i++)
            {
                columns[i] = new StringBuilder(cols[i]);
            }

            // Perform 31 shifts for each.
            int[] sh = new int[4];
            for (sh[0] = 0; sh[0] < 31; sh[0]++)
            {
                for (sh[1] = 0; sh[1] < 31; sh[1]++)
                {

                    if (sh[0] != 20)
                    {
                        break;
                    }

                    for (sh[2] = 0; sh[2] < 31; sh[2]++)
                    {
                        for (sh[3] = 0; sh[3] < 31; sh[3]++)
                        {
                            // This place will execute 31 ^ 4 times.
                            for (int k = 0; k < columns[4].Length; k++)
                            {
                                columns[4][k]++;
                                if (columns[4][k] > 'я')
                                {
                                    columns[4][k] = 'а';
                                }
                                else if (columns[4][k] == 'ъ')
                                {
                                    columns[4][k] = 'ы';
                                }
                            }
                            /*
                                                        if (!(sh[0] == 13 && sh[1] == 7 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 13 && sh[1] == 27 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 14 && sh[1] == 7 && sh[2] == 20 && sh[3] == 18 ||
                                                            sh[0] == 14 && sh[1] == 7 && sh[2] == 20 && sh[3] == 30 ||
                                                            sh[0] == 16 && sh[1] == 22 && sh[2] == 20 && sh[3] == 5 ||
                                                            sh[0] == 16 && sh[1] == 22 && sh[2] == 20 && sh[3] == 14 ||
                                                            sh[0] == 16 && sh[1] == 22 && sh[2] == 20 && sh[3] == 27 ||
                                                            sh[0] == 17 && sh[1] == 7 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 17 && sh[1] == 20 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 17 && sh[1] == 23 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 17 && sh[1] == 27 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 19 && sh[1] == 9 && sh[2] == 23 && sh[3] == 20 ||
                                                            sh[0] == 20 && sh[1] == 7 && sh[2] == 0 && sh[3] == 18 ||
                                                            sh[0] == 20 && sh[1] == 7 && sh[2] == 21 && sh[3] == 18 ||
                                                            sh[0] == 20 && sh[1] == 10 && sh[2] == 24 && sh[3] == 21 ||
                                                            sh[0] == 20 && sh[1] == 10 && sh[2] == 28 && sh[3] == 21 ||
                                                            sh[0] == 20 && sh[1] == 21 && sh[2] == 28 && sh[3] == 21 ||
                                                            sh[0] == 20 && sh[1] == 27 && sh[2] == 0 && sh[3] == 18 ||
                                                            sh[0] == 20 && sh[1] == 27 && sh[2] == 21 && sh[3] == 18)
                                                            )
                                                        {
                                                            continue;
                                                        }
                            */
                            // Letter IS.
                            int maxLetterCount = 0;
                            double letterIS = CountLetterIS(columns, out maxLetterCount);

                            // Bigram IS.
                            int maxBigramCount = 0;
                            double bigramIS = CountBigramIS(columns, out maxBigramCount);

                            // Trigram IS.
                            int maxTrigramCount = 0;
                            double trigramIS = CountTrigramIS(columns, out maxTrigramCount);

                            /* Letter IS ~= 0.05500;
                             * Bigram IS ~= 0.00600;
                             * Trigram IS ~= 0.00100;
                             * Max bigram count ~= 7-9 per 300 letters;
                             * Max trigram count ~= 3-4 per 300 letters.
                            */
                            if (letterIS > 0.04100 &&
                                bigramIS > 0.00260 &&
                                trigramIS > 0.00030 &&
                                maxBigramCount > 5 &&
                                maxTrigramCount > 2
                                )
                            {
                                Console.WriteLine("Iter. {0}-{1}-{2}-{3}", sh[0], sh[1], sh[2], sh[3]);
                                Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}\n",
                                    letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);

                                // Attach 3 more columns.
                                StringBuilder[] columnsA3 = new StringBuilder[8];
                                for (int l = 0; l < 5; l++)
                                {
                                    columnsA3[l] = columns[l];
                                }
                                for (int l = 5; l < 8; l++)
                                {
                                    columnsA3[l] = new StringBuilder(cols[l]);
                                }

                                // Perform shifts for them.
                                int[] shA3 = new int[3];
                                for (shA3[0] = 0; shA3[0] < 31; shA3[0]++)
                                {
                                    for (shA3[1] = 0; shA3[1] < 31; shA3[1]++)
                                    {
                                        for (shA3[2] = 0; shA3[2] < 31; shA3[2]++)
                                        {
                                            for (int k = 0; k < columnsA3[7].Length; k++)
                                            {
                                                columnsA3[7][k]++;
                                                if (columnsA3[7][k] > 'я')
                                                {
                                                    columnsA3[7][k] = 'а';
                                                }
                                                else if (columnsA3[7][k] == 'ъ')
                                                {
                                                    columnsA3[7][k] = 'ы';
                                                }
                                            }


                                            // Check stats here.
                                            // Letter IS.
                                            maxLetterCount = 0;
                                            letterIS = CountLetterIS(columnsA3, out maxLetterCount);

                                            // Bigram IS.
                                            maxBigramCount = 0;
                                            bigramIS = CountBigramIS(columnsA3, out maxBigramCount);

                                            // Trigram IS.
                                            maxTrigramCount = 0;
                                            trigramIS = CountTrigramIS(columnsA3, out maxTrigramCount);

                                            /* Letter IS ~= 0.05500;
                                             * Bigram IS ~= 0.00600;
                                             * Trigram IS ~= 0.00100.
                                            */
                                            if (letterIS > 0.04000 &&
                                                bigramIS > 0.00200 &&
                                                trigramIS > 0.00030
                                                )
                                            {
                                                Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}",
                                               sh[0], sh[1], sh[2], sh[3], shA3[0], shA3[1], shA3[2]);
                                                Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                    letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);

                                                // Attach 4 more columns.
                                                StringBuilder[] columnsA4 = new StringBuilder[12];
                                                for (int l = 0; l < 8; l++)
                                                {
                                                    columnsA4[l] = columnsA3[l];
                                                }
                                                for (int l = 8; l < 12; l++)
                                                {
                                                    columnsA4[l] = new StringBuilder(cols[l]);
                                                }

                                                // Perform shifts for them.
                                                int[] shA4 = new int[4];
                                                for (shA4[0] = 0; shA4[0] < 31; shA4[0]++)
                                                {
                                                    for (shA4[1] = 0; shA4[1] < 31; shA4[1]++)
                                                    {
                                                        for (shA4[2] = 0; shA4[2] < 31; shA4[2]++)
                                                        {
                                                            for (shA4[3] = 0; shA4[3] < 31; shA4[3]++)
                                                            {
                                                                for (int k = 0; k < columnsA4[11].Length; k++)
                                                                {
                                                                    columnsA4[11][k]++;
                                                                    if (columnsA4[11][k] > 'я')
                                                                    {
                                                                        columnsA4[11][k] = 'а';
                                                                    }
                                                                    else if (columnsA4[11][k] == 'ъ')
                                                                    {
                                                                        columnsA4[11][k] = 'ы';
                                                                    }
                                                                }


                                                                // Check stats here.
                                                                // Letter IS.
                                                                maxLetterCount = 0;
                                                                letterIS = CountLetterIS(columnsA4, out maxLetterCount);

                                                                // Bigram IS.
                                                                maxBigramCount = 0;
                                                                bigramIS = CountBigramIS(columnsA4, out maxBigramCount);

                                                                // Trigram IS.
                                                                maxTrigramCount = 0;
                                                                trigramIS = CountTrigramIS(columnsA4, out maxTrigramCount);

                                                                /* Letter IS ~= 0.05500;
                                                                 * Bigram IS ~= 0.00600;
                                                                 * Trigram IS ~= 0.00100
                                                                */

                                                                if (letterIS > 0.04100 &&
                                                                    bigramIS > 0.00250 &&
                                                                    trigramIS > 0.00030
                                                                    )
                                                                {

                                                                    Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}--{7}-{8}-{9}-{10}",
                                                                    sh[0], sh[1], sh[2], sh[3], shA3[0], shA3[1], shA3[2],
                                                                    shA4[0], shA4[1], shA4[2], shA4[3]);
                                                                    Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                                        letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);

                                                                    /*
                                                                    // Attach 4 more columns.
                                                                    StringBuilder[] columnsA44 = new StringBuilder[16];
                                                                    for (int l = 0; l < 12; l++)
                                                                    {
                                                                        columnsA44[l] = columnsA4[l];
                                                                    }
                                                                    for (int l = 12; l < 16; l++)
                                                                    {
                                                                        columnsA44[l] = new StringBuilder(cols[l]);
                                                                    }

                                                                    // Perform shifts for them.
                                                                    int[] shA44 = new int[4];
                                                                    for (shA44[0] = 0; shA44[0] < 31; shA44[0]++)
                                                                    {
                                                                        for (shA44[1] = 0; shA44[1] < 31; shA44[1]++)
                                                                        {
                                                                            for (shA44[2] = 0; shA44[2] < 31; shA44[2]++)
                                                                            {
                                                                                for (shA44[3] = 0; shA44[3] < 31; shA44[3]++)
                                                                                {
                                                                                    for (int k = 0; k < columnsA44[15].Length; k++)
                                                                                    {
                                                                                        columnsA44[15][k]++;
                                                                                        if (columnsA44[15][k] > 'я')
                                                                                        {
                                                                                            columnsA44[15][k] = 'а';
                                                                                        }
                                                                                        else if (columnsA44[15][k] == 'ъ')
                                                                                        {
                                                                                            columnsA44[15][k] = 'ы';
                                                                                        }
                                                                                    }
                                                                                    /*
                                                                                    if (!(sh[0] == 14 && sh[1] == 7 && sh[2] == 20 && sh[3] == 18 &&
                                                                                        shA3[0] == 26 && shA3[1] == 5 && shA3[2] == 11))
                                                                                    {
                                                                                        continue;
                                                                                    }
                                                                                    
                                                                                    // Check stats here.
                                                                                    // Letter IS.
                                                                                    maxLetterCount = 0;
                                                                                    letterIS = CountLetterIS(columnsA44, out maxLetterCount);

                                                                                    // Bigram IS.
                                                                                    maxBigramCount = 0;
                                                                                    bigramIS = CountBigramIS(columnsA44, out maxBigramCount);

                                                                                    // Trigram IS.
                                                                                    maxTrigramCount = 0;
                                                                                    trigramIS = CountTrigramIS(columnsA44, out maxTrigramCount);

                                                                                    /* Letter IS ~= 0.05500;
                                                                                     * Bigram IS ~= 0.00600;
                                                                                     * Trigram IS ~= 0.00100;
                                                                                     * Max bigram count ~= 7-9;
                                                                                     * Max trigram count ~= 3-4.
                                                                                    
                                                                                    if (letterIS > 0.05000 ||
                                                                                        bigramIS > 0.00300 ||
                                                                                        trigramIS > 0.00050 // ||
                                                                                                            //maxBigramCount > 8 ||
                                                                                                            //maxTrigramCount > 4
                                                                                        )
                                                                                    {

                                                                                        Console.WriteLine("Iter. {0}-{1}-{2}-{3}--{4}-{5}-{6}--{7}-{8}-{9}-{10}--{11}-{12}-{13}-{14}",
                                                                                        sh[0], sh[1], sh[2], sh[3], shA3[0], shA3[1], shA3[2],
                                                                                        shA4[0], shA4[1], shA4[2], shA4[3], shA44[0], shA44[1], shA44[2], shA44[3]);
                                                                                        Console.WriteLine("LIS: {0:F5}, max = {1}\nBIS: {2:F5}, max = {3}\nTIS: {4:F5}, max = {5}",
                                                                                            letterIS, maxLetterCount, bigramIS, maxBigramCount, trigramIS, maxTrigramCount);
                                                                                        //Console.ReadKey();

                                                                                    }
                                                                                }

                                                                                for (int k = 0; k < columnsA44[14].Length; k++)
                                                                                {
                                                                                    columnsA44[14][k]++;
                                                                                    if (columnsA44[14][k] > 'я')
                                                                                    {
                                                                                        columnsA44[14][k] = 'а';
                                                                                    }
                                                                                    else if (columnsA44[14][k] == 'ъ')
                                                                                    {
                                                                                        columnsA44[14][k] = 'ы';
                                                                                    }
                                                                                }
                                                                            }

                                                                            for (int k = 0; k < columnsA44[13].Length; k++)
                                                                            {
                                                                                columnsA44[13][k]++;
                                                                                if (columnsA44[13][k] > 'я')
                                                                                {
                                                                                    columnsA44[13][k] = 'а';
                                                                                }
                                                                                else if (columnsA44[13][k] == 'ъ')
                                                                                {
                                                                                    columnsA44[13][k] = 'ы';
                                                                                }
                                                                            }
                                                                        }

                                                                        for (int k = 0; k < columnsA44[12].Length; k++)
                                                                        {
                                                                            columnsA44[12][k]++;
                                                                            if (columnsA44[12][k] > 'я')
                                                                            {
                                                                                columnsA44[12][k] = 'а';
                                                                            }
                                                                            else if (columnsA44[12][k] == 'ъ')
                                                                            {
                                                                                columnsA44[12][k] = 'ы';
                                                                            }
                                                                        }
                                                                    }
                                                                    */

                                                                    //Console.ReadKey();

                                                                }
                                                            }

                                                            for (int k = 0; k < columnsA4[10].Length; k++)
                                                            {
                                                                columnsA4[10][k]++;
                                                                if (columnsA4[10][k] > 'я')
                                                                {
                                                                    columnsA4[10][k] = 'а';
                                                                }
                                                                else if (columnsA4[10][k] == 'ъ')
                                                                {
                                                                    columnsA4[10][k] = 'ы';
                                                                }
                                                            }
                                                        }

                                                        for (int k = 0; k < columnsA4[9].Length; k++)
                                                        {
                                                            columnsA4[9][k]++;
                                                            if (columnsA4[9][k] > 'я')
                                                            {
                                                                columnsA4[9][k] = 'а';
                                                            }
                                                            else if (columnsA4[9][k] == 'ъ')
                                                            {
                                                                columnsA4[9][k] = 'ы';
                                                            }
                                                        }
                                                    }

                                                    for (int k = 0; k < columnsA4[8].Length; k++)
                                                    {
                                                        columnsA4[8][k]++;
                                                        if (columnsA4[8][k] > 'я')
                                                        {
                                                            columnsA4[8][k] = 'а';
                                                        }
                                                        else if (columnsA4[8][k] == 'ъ')
                                                        {
                                                            columnsA4[8][k] = 'ы';
                                                        }
                                                    }
                                                }



                                                //Console.ReadKey();

                                            }
                                        }

                                        for (int k = 0; k < columnsA3[6].Length; k++)
                                        {
                                            columnsA3[6][k]++;
                                            if (columnsA3[6][k] > 'я')
                                            {
                                                columnsA3[6][k] = 'а';
                                            }
                                            else if (columnsA3[6][k] == 'ъ')
                                            {
                                                columnsA3[6][k] = 'ы';
                                            }
                                        }
                                    }

                                    for (int k = 0; k < columnsA3[5].Length; k++)
                                    {
                                        columnsA3[5][k]++;
                                        if (columnsA3[5][k] > 'я')
                                        {
                                            columnsA3[5][k] = 'а';
                                        }
                                        else if (columnsA3[5][k] == 'ъ')
                                        {
                                            columnsA3[5][k] = 'ы';
                                        }
                                    }
                                }
                                //Console.ReadKey();

                            }

                        }

                        for (int k = 0; k < columns[3].Length; k++)
                        {
                            columns[3][k]++;
                            if (columns[3][k] > 'я')
                            {
                                columns[3][k] = 'а';
                            }
                            else if (columns[3][k] == 'ъ')
                            {
                                columns[3][k] = 'ы';
                            }
                        }
                    }

                    for (int k = 0; k < columns[2].Length; k++)
                    {
                        columns[2][k]++;
                        if (columns[2][k] > 'я')
                        {
                            columns[2][k] = 'а';
                        }
                        else if (columns[2][k] == 'ъ')
                        {
                            columns[2][k] = 'ы';
                        }
                    }
                }

                for (int k = 0; k < columns[1].Length; k++)
                {
                    columns[1][k]++;
                    if (columns[1][k] > 'я')
                    {
                        columns[1][k] = 'а';
                    }
                    else if (columns[1][k] == 'ъ')
                    {
                        columns[1][k] = 'ы';
                    }
                }

                Console.WriteLine("{0} of 31 cycles passed...", sh[0]);
            }

        }

        public static void PereborIter()
        {
            Random rand = new Random();
            int[] shifts = new int[16];
            for (int i = 1; i < 16; i++)
            {
                shifts[i] = rand.Next(0, 31);
            }
            StringBuilder txt = new StringBuilder(text);
            int cntr = 0;
            while (true)
            {
                Console.WriteLine("Passed {0} iterations...", cntr);
                Console.Write("IS = {0}, shifts: 0 ", Math.Round(TestTextIS(txt), 5));
                for (int i = 1; i < 16; i++)
                {
                    Console.Write("{0} ", shifts[i]);
                }
                Console.WriteLine();
                Console.WriteLine(txt);
                Console.ReadKey();
                /*
                if (cntr % 3 == 0)
                {
                    // Add some random.
                    for (int l = 1; l < 16; l++)
                    {
                        int r = rand.Next(1, 31);
                        //if (r > 0)
                        {
                            shifts[l] += r;
                            shifts[l] %= 31;
                            StringBuilder newtxt = txt;
                            for (int j = l; j < newtxt.Length; j += 16)
                            {
                                int code = (newtxt[j] <= 'щ') ? (newtxt[j] - 'а') : (newtxt[j] - 'а' - 1);
                                code += r;
                                code %= 31;
                                code = (code + 'а' <= 'щ') ? (code + 'а') : (code + 'а' + 1);
                                newtxt[j] = (char)code;
                            }
                            if (TestTextIS(newtxt) > TestTextIS(txt))
                            {
                                txt = newtxt;
                            }
                        }
                    }
                }
                */
                for (int i = 1; i < 16; i++)
                {
                    double[] iss = new double[31];
                    for (int shift = 0; shift < 31; shift++)
                    {
                        iss[shift] = TestTextIS(txt);
                        for (int k = i; k < txt.Length; k += 16)
                        {
                            txt[k]++;
                            if (txt[k] > 'я')
                            {
                                txt[k] = 'а';
                            }
                            else if (txt[k] == 'ъ')
                            {
                                txt[k] = 'ы';
                            }
                        }
                    }
                    // Find the most suitable shift.
                    int index = Array.IndexOf(iss, iss.Max());
                    shifts[i] += index;
                    shifts[i] %= 31;
                    // Shift the text accordingly.
                    for (int j = i; j < txt.Length; j += 16)
                    {
                        int code = (txt[j] <= 'щ') ? (txt[j] - 'а') : (txt[j] - 'а' - 1);
                        code += index;
                        code %= 31;
                        code = (code + 'а' <= 'щ') ? (code + 'а') : (code + 'а' + 1);
                        txt[j] = (char)code;
                    }
                }
                cntr++;
            }
        }

        public static void Perebor3()
        {
            int[] i = new int[16];
            int[,] shifts =
            {
                { 0, 0, 0 },
                { 20, 19, 0 },
                { 27, 21, 7 },
                { 21, 20, 28 },
                { 19, 16, 22 },
                { 24, 22, 23 },
                { 5, 4, 0 },
                { 12, 30, 25 },
                { 9, 10, 28 },
                { 25, 23, 24 },
                { 1, 2, 21 },
                { 27, 14, 15 },
                { 13, 21, 0 },
                { 9, 10, 0 },
                { 14, 7, 0 },
                { 18, 21, 16 }
            };
            for (i[1] = 0; i[1] < 2; i[1]++)
            {
                for (i[2] = 0; i[2] < 3; i[2]++)
                {
                    for (i[3] = 0; i[3] < 3; i[3]++)
                    {
                        for (i[4] = 0; i[4] < 3; i[4]++)
                        {
                            for (i[5] = 0; i[5] < 3; i[5]++)
                            {
                                for (i[6] = 0; i[6] < 2; i[6]++)
                                {
                                    for (i[7] = 0; i[7] < 3; i[7]++)
                                    {
                                        for (i[8] = 0; i[8] < 3; i[8]++)
                                        {
                                            for (i[9] = 0; i[9] < 3; i[9]++)
                                            {
                                                for (i[10] = 0; i[10] < 3; i[10]++)
                                                {
                                                    for (i[11] = 0; i[11] < 3; i[11]++)
                                                    {
                                                        for (i[12] = 0; i[12] < 2; i[12]++)
                                                        {
                                                            for (i[13] = 0; i[13] < 2; i[13]++)
                                                            {
                                                                for (i[14] = 0; i[14] < 2; i[14]++)
                                                                {
                                                                    for (i[15] = 0; i[15] < 3; i[15]++)
                                                                    {
                                                                        StringBuilder str = new StringBuilder(text.Length);
                                                                        int letter = 0;
                                                                        for (int l = 0; l < text.Length; l++)
                                                                        {
                                                                            int code = (text[l] <= 'щ') ? (text[l] - 'а') : (text[l] - 'а' - 1);
                                                                            code -= shifts[letter, i[letter]];
                                                                            code = (code < 0 ? code + 31 : code) % 31;
                                                                            code = (code + 'а' <= 'щ') ? (code + 'а') : (code + 'а' + 1);
                                                                            str.Append((char)code);
                                                                            letter++;
                                                                            if (letter >= 16)
                                                                            {
                                                                                letter = 0;
                                                                            }
                                                                        }
                                                                        double IS = TestTextIS(str);
                                                                        if (IS > 0.05)
                                                                        {
                                                                            Console.Write("IS = {0}, shifts: ", Math.Round(IS, 5));
                                                                            for (int m = 0; m < 16; m++)
                                                                            {
                                                                                Console.Write("{0} ", shifts[m, i[m]]);
                                                                            }
                                                                            Console.WriteLine();
                                                                            //Console.WriteLine("{0}", str);
                                                                            //Console.ReadKey();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Console.WriteLine("100k iterations passed...");
                    }
                }
            }
        }

        public static double TestTextIS(StringBuilder str)
        {
            double index = 0;
            for (int j = 0; j < 31; j++)
            {
                int cnt = 0;
                char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ltr)
                    {
                        cnt++;
                    }
                }
                //Console.WriteLine(cnt);
                //Console.WriteLine(str.Length);
                index += (cnt * (cnt - 1)) / (double)(str.Length * (str.Length - 1));
                //Console.WriteLine(index);
            }
            return index;
        }

        public static void TestOpenText()
        {
            double index = 0;
            for (int j = 0; j < 31; j++)
            {
                int cnt = 0;
                char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                for (int i = 0; i < opentext.Length; i++)
                {
                    if (opentext[i] == ltr)
                    {
                        cnt++;
                    }
                }
                index += (cnt * (cnt - 1)) / (double)(opentext.Length * (opentext.Length - 1));
            }
            Console.WriteLine("IS opentext = {0}\nStop!", Math.Round(index, 4));
            Console.ReadKey();
        }

        public static void VzaimnoWithFirstColumn(int len)
        {
            string[] columns = DivideTextIntoColumns(len);
            int[] cnt1 = new int[31];
            double n1 = columns[0].Length;

            for (int j = 0; j < 31; j++)
            {
                char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                for (int k = 0; k < columns[0].Length; k++)
                {
                    if (columns[0][k] == ltr)
                    {
                        cnt1[j]++;
                    }
                }
            }

            for (int i = 1; i < len; i++)
            {
                double[] indexes = new double[31];
                for (int shift = 0; shift < 31; shift++)
                {
                    double index = 0;
                    double n2 = columns[i].Length;
                    for (int j = 0; j < 31; j++)
                    {
                        int cnt2 = 0;
                        char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                        for (int k = 0; k < columns[i].Length; k++)
                        {
                            if (columns[i][k] == ltr)
                            {
                                cnt2++;
                            }
                        }
                        index += cnt1[j] * cnt2;
                    }
                    index /= (n1 * n2);
                    if (index > 0.04)
                    {
                        Console.WriteLine("Column {0}, shift {1}; IS = {2}", i, shift, Math.Round(index, 4));
                        //Console.ReadKey();
                    }
                    string newcolumn = "";
                    for (int j = 0; j < columns[i].Length; j++)
                    {
                        int newletter = ((columns[i][j] == 'я') ? 'а' : columns[i][j] + 1);
                        if (newletter == 'ъ')
                        {
                            newletter++;
                        }
                        newcolumn += (char)newletter;
                    }
                    columns[i] = newcolumn;
                    indexes[shift] = index;
                }
            }
            Console.WriteLine("Fin!");
            Console.ReadKey();
        }

        public static string[] DivideTextIntoColumns(int len)
        {
            string[] columns = new string[len];
            int a = 0;
            for (int i = 0; i < text.Length; i++)
            {
                columns[a] += text[i];
                a++;
                if (a >= len)
                {
                    a = 0;
                }
            }
            return columns;
        }

        public static void TestKeyLength(int len)
        {
            string[] columns = DivideTextIntoColumns(len);

            for (int i = 0; i < len; i++)
            {
                double index = 0;
                for (int j = 0; j < 31; j++)
                {
                    int cnt = 0;
                    char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                    double n = 0;
                    for (int k = 0; k < columns[i].Length; k++)
                    {
                        if (columns[i][k] == ltr)
                        {
                            cnt++;
                        }
                        n++;
                    }
                    index += (cnt * (cnt - 1)) / (n * (n - 1));
                }

                Console.WriteLine("Column {0}, IS = {1}", i, Math.Round(index, 4));
                //Console.ReadKey();

            }
            Console.WriteLine("Fin!");
            Console.ReadKey();
        }

        public static void IndexSovpadenia2(bool mode)
        {
            for (int shift = 2; shift < 80; shift++)
            {
                double index = 0;
                for (int j = 0; j < 31; j++)
                {
                    int cnt = 0;
                    char ltr = (char)('а' + j + (j > 25 ? 1 : 0));
                    for (int i = 0; i < text.Length; i += shift)
                    {
                        if (text[i] == ltr)
                        {
                            cnt++;
                        }
                    }
                    double n = Math.Floor(text.Length / (double)shift);
                    index += (cnt * (cnt - 1)) / (n * (n - 1));
                }
                if (mode)
                {
                    if (index > 0.05)
                    {
                        Console.WriteLine("Key length = {0}, IS = {1}", shift, Math.Round(index, 4));
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Key length = {0}, IS = {1}", shift, Math.Round(index, 4));
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Stop!");
            Console.ReadKey();
        }

        public static void IndexSovpadenia1(bool mode)
        {
            for (int shift = 2; shift < 80; shift++)
            {
                double sovpadeniaCnt = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == text[((i + shift >= text.Length) ? (i + shift - text.Length) : (i + shift))])
                    {
                        sovpadeniaCnt++;
                    }
                }
                sovpadeniaCnt /= text.Length;
                if (mode)
                {
                    if (sovpadeniaCnt > 0.05)
                    {
                        Console.WriteLine("Key length = {0}, IS = {1}", shift, Math.Round(sovpadeniaCnt, 4));
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Key length = {0}, IS = {1}", shift, Math.Round(sovpadeniaCnt, 4));
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Stop!");
            Console.ReadKey();
        }

        
        public static void Kaziski()
        {
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    bigrams[i, j].c1 = alphabet[i];
                    bigrams[i, j].c2 = alphabet[j];
                    bigrams[i, j].incls = new List<int>();
                }
            }
            for (int i = 0; i < text.Length - 1; i++)
            {
                int i1 = (text[i] <= 'щ' ? text[i] - 'а' : text[i] - 'а' - 1);
                int i2 = (text[i + 1] <= 'щ' ? text[i + 1] - 'а' : text[i + 1] - 'а' - 1);
                bigrams[i1, i2].incls.Add(i);
            }
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (bigrams[i, j].incls.Count > 4)
                    {
                        Console.Write("{0}{1}: ", bigrams[i, j].c1, bigrams[i, j].c2);
                        for (int k = 0; k < bigrams[i, j].incls.Count - 1; k++)
                        {
                            Console.Write("{0}, ", bigrams[i, j].incls[k + 1] - bigrams[i, j].incls[k]);
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();

            int[,] freqs = new int[cnt, 32];
            for (int i = 0; i < cnt; i++)
            {
                for (int j = i; j < text.Length; j += cnt)
                {
                    freqs[i, text[j] - 'а']++;
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                Console.WriteLine("\nShift {0}:", i);
                for (int j = 0; j < 32; j++)
                {
                    Console.Write("{0}: ", (char)(j + 'а'));
                    for (int k = 0; k < freqs[i, j]; k++)
                    {
                        Console.Write("##");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
