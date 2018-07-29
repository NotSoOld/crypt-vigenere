using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigenerDecoder
{
    public partial class Form1 : Form
    {
        string text = "жочццимжвоюэфлщщяычжнхюофуогевиепцгщкщвснжзгсьюлнсййчжцфкйрпебхояфмйюр" +
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
        // string text = "бхкврыяхядйоньефщсв";
        //string text = "веыаюофквб";

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 20; i++)
            {
                shifts.Columns.Add("", "");
                shifts.Columns[i].Width = 50;
                shifts[i, 0].Value = 0;
            }
            shifts.Rows[0].Height = 40;
        }

        void updateText()
        {
            textBox.Text = "";
            int letter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                int code = (text[i] <= 'щ') ? (text[i] - 'а') : (text[i] - 'а' - 1);
                code -= int.Parse(shifts[letter, 0].Value.ToString());
                code = (code < 0 ? code + 31 : code) % 31;
                code = (code + 'а' <= 'щ') ? (code + 'а') : (code + 'а' + 1);
                textBox.Text += (char)code;
                letter++;
                if (letter >= letterCnt.Value)
                {
                    letter = 0;
                }
            }
        }

        private void letterCnt_ValueChanged(object sender, EventArgs e)
        {
            if (letterCnt.Value >= 4 && letterCnt.Value <= 20)
            {
                updateText();
            }
        }

        private void shifts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (letterCnt.Value >= 4 && letterCnt.Value <= 20)
            {
                updateText();
            }
        }
    }
}
