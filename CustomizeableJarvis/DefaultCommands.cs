using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using JarvisReiven.Properties;
using System.Globalization;
using JarvisReiven.Properties;

namespace JarvisReiven
{
    public partial class frmMain : Form
    {
        Random rnd = new Random();
        public static List<string> MsgList = new List<string>();
        public static List<string> MsgLink = new List<string>();
        int count = 1;
        int timer = 11;
        int EmailNum = 0;
        DateTime timenow = DateTime.Now;
        public static String Temperature, Condition, Humidity, WinSpeed, TFCond, TFHigh, TFLow, Town;

        void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;
            switch (speech)
            {
                #region Greetings
                case "Olá":
                case "Olá Reíven":
                    timenow = DateTime.Now;
                    if (timenow.Hour >= 5 && timenow.Hour < 12)
                    { Jarvis.SpeakAsync("Bom dia " + Settings.Default.User); }
                    if (timenow.Hour >= 12 && timenow.Hour < 18)
                    { Jarvis.SpeakAsync("Boa tarde " + Settings.Default.User); }
                    if (timenow.Hour >= 18 && timenow.Hour < 24)
                    { Jarvis.SpeakAsync("Boa noite " + Settings.Default.User); }
                    if (timenow.Hour < 5)
                    { Jarvis.SpeakAsync("Olá " + Settings.Default.User + ", falta poucas horas para amanhecer!"); }
                    break;

                case "Até a próxima Reíven":
                case "Até mais Reíven":
                case "Desliga-se Reíven":
                    Jarvis.Speak("Ok, fique bem e até a próxima.");
                    Close();
                    break;

                case "Reiven":
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 1) { QEvent = ""; Jarvis.SpeakAsync("Sim " + Settings.Default.User); }
                    else if (ranNum == 2) { QEvent = ""; Jarvis.SpeakAsync("Sim?"); }
                    else if (ranNum == 3) { QEvent = ""; Jarvis.SpeakAsync("Como posso ajudá-te?"); }
                    else if (ranNum == 4) { QEvent = ""; Jarvis.SpeakAsync("Como posso dar-te assistência?"); }
                    break;

                case "Como me chamo?":
                    Jarvis.SpeakAsync("Você se chama, " + Settings.Default.User + ". E eu me chamo, Reíven.");
                    break;

                case "Pare de falar":
                    Jarvis.SpeakAsyncCancelAll();
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 5)
                    { Jarvis.Speak("Certo"); }
                    break;
                #endregion

                #region Condition of the Day
                case "Que horas são":
                    timenow = DateTime.Now;
                    string time = timenow.GetDateTimeFormats('t')[0];
                    Jarvis.SpeakAsync(time);
                    break;

                case "Que dia é hoje":
                    Jarvis.SpeakAsync(DateTime.Today.ToString("dddd"));
                    break;

                case "Qual é a data":
                case "Data de hoje ":
                    Jarvis.SpeakAsync(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;

                case "Como está o tempo":
                case "Me fala do tempo":
                case "Como vai o tempo":
                    RSSReader.GetWeather();
                    if (QEvent == "connected")
                    { Jarvis.SpeakAsync("O tempo em " + Town + " está " + Condition + " a " + Temperature + " graus. A humidade é " + Humidity + " e a velocidade do vento é " + WinSpeed + " milhas por hora"); }
                    else if (QEvent == "failed")
                    { Jarvis.SpeakAsync("Estou tendo dificuldade em me conectar com o servidor. Melhor ires ver o como está o tempo pela janela."); }
                    break;

                case "Como será a previsão para amanhã":
                case "Qual é previsão para amanhã":
                case "Amanhã será igual ao tempo de hoje":
                    RSSReader.GetWeather();
                    if (QEvent == "connected")
                    { Jarvis.SpeakAsync("A previsão de amanhã é " + TFCond + " com alta de " + TFHigh + " e uma baixa de " + TFLow); }
                    else if (QEvent == "failed")
                    { Jarvis.SpeakAsync("Eu não pude aceder ao servidor. Tens a certeza que tens WOEID correcto?"); }
                    break;

                case "Como está a temperatura":
                case "Como está a temperatura la fora":
                    RSSReader.GetWeather();
                    if (QEvent == "connected")
                    { Jarvis.SpeakAsync(Temperature + " graus"); }
                    else if (QEvent == "failed")
                    { Jarvis.SpeakAsync("Eu não pude conectar aos serviços do tempo"); }
                    break;
                #endregion

                #region Application Commands
                case "Trocar Janela":
                    SendKeys.SendWait("%{TAB " + count + "}");
                    count += 1;
                    break;

                case "Fechar Janela":
                    SendKeys.SendWait("%{F4}");
                    break;

                case "Reíven saia da frente":
                    if (WindowState == FormWindowState.Normal)
                    {
                        WindowState = FormWindowState.Minimized;
                        Jarvis.SpeakAsync("Minhas desculpas");
                    }
                    break;

                case "Reíven apareça":
                    if (WindowState == FormWindowState.Minimized)
                    {
                        Jarvis.SpeakAsync("Certo");
                        WindowState = FormWindowState.Normal;
                    }
                    break;

                case "Mostrar todos comandos":
                    string[] defaultcommands = (File.ReadAllLines(@"Default Commands.txt"));
                    Jarvis.SpeakAsync("Muito bem");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in defaultcommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;

                case "Mostrar comandos shell":
                    Jarvis.SpeakAsync("Aqui estão");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArrayShellCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;

                case "Mostrar comandos sociais":
                    Jarvis.SpeakAsync("Com certeza");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArraySocialCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;

                case "Mostrar comandos web":
                    Jarvis.SpeakAsync("Ok");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in ArrayWebCommands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;
                case "Mostrar Biblioteca de musica":
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    Jarvis.SpeakAsync("OK");
                    i = 0;
                    foreach (string file in MyMusicPaths)
                    {
                        lstCommands.Items.Add(MyMusicNames[i]);
                        i += 1;
                    }
                    QEvent = "Reproduzir ficheiro de musica";
                    break;

                case "Mostrar Biblioteca de Video":
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    i = 0;
                    foreach (string file in MyVideoPaths)
                    {
                        if (file.Contains(".mp4") || file.Contains(".avi") || file.Contains(".mkv"))
                        { lstCommands.Items.Add(MyVideoNames[i]); i += 1; }
                        else { i += 1; }
                    }
                    QEvent = "Reproduzir ficheiro de video";
                    break;

                case "Mostrar liste de Email":
                    lstCommands.SelectionMode = SelectionMode.One;
                    lstCommands.Items.Clear();
                    lstCommands.Visible = true;
                    foreach (string line in MsgList)
                    {
                        lstCommands.Items.Add(line);
                    }
                    QEvent = "Checkfornewemails";
                    break;

                case "Mostrar lista":
                    lstCommands.Visible = true;
                    break;

                case "Ocultar lista":
                    lstCommands.Visible = false;
                    break;
                #endregion

                #region Shutdown / Restart / Logoff
                case "Desligar PC":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "desligar pc";
                        Jarvis.SpeakAsync("Tens a certeza que queres " + QEvent + "?");
                    }
                    break;

                case "Terminar PC":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "terminar pc";
                        Jarvis.SpeakAsync("Tens a certeza que queres " + QEvent + "?");
                    }
                    break;

                case "Reiniciar PC":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "reiniciar pc";
                        Jarvis.SpeakAsync("Tens a certeza que queres " + QEvent + "?");
                    }
                    break;

                case "Cancelar":
                    if (ShutdownTimer.Enabled == true)
                    {
                        timer = 11;
                        lblTimer.Text = timer.ToString();
                        ShutdownTimer.Enabled = false;
                        lblTimer.Visible = false;
                    }
                    break;
                #endregion

                #region Media Control Commands
                case "Tocar":
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    axWindowsMediaPlayer1.Visible = true;
                    break;
                case "Tocar qualquer musica":
                    int Ran = rnd.Next(0, MyMusicPaths.Count());
                    SelectedMusicFile = Ran;
                    Jarvis.SpeakAsync("Espero que estejas com disposição para ouvir " + MyMusicNames[SelectedMusicFile]);
                    axWindowsMediaPlayer1.URL = MyMusicPaths[SelectedMusicFile];
                    break;
                case "Você decide":
                    if (QEvent == "Tocar musica")
                    {
                        Ran = rnd.Next(0, MyMusicPaths.Count());
                        SelectedMusicFile = Ran;
                        Jarvis.SpeakAsync("Que tal " + MyMusicNames[SelectedMusicFile] + "?");
                        axWindowsMediaPlayer1.URL = MyMusicPaths[SelectedMusicFile];
                    }
                    break;
                case "Pause":
                    tmrMusic.Stop();
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    break;
                case "Turn Shuffle On":
                    Settings.Default.Shuffle = true;
                    Settings.Default.Save();
                    Jarvis.SpeakAsync("Shuffle enabled");
                    break;
                case "Turn Shuffle Off":
                    Settings.Default.Shuffle = false;
                    Settings.Default.Save();
                    Jarvis.SpeakAsync("Shuffle disabled");
                    break;
                case "Almentar Volume":
                    axWindowsMediaPlayer1.settings.volume += 10;
                    lblVolume.Text = axWindowsMediaPlayer1.settings.volume.ToString() + "%";
                    tbarVolume.Value = axWindowsMediaPlayer1.settings.volume;
                    break;
                case "Baixar Volume":
                    axWindowsMediaPlayer1.settings.volume -= 10;
                    lblVolume.Text = axWindowsMediaPlayer1.settings.volume.ToString() + "%";
                    tbarVolume.Value = axWindowsMediaPlayer1.settings.volume;
                    break;
                case "Tirar Volume":
                    axWindowsMediaPlayer1.settings.mute = true;
                    lblVolume.Text = "mute";
                    break;
                case "Meter Volume":
                    axWindowsMediaPlayer1.settings.mute = false;
                    lblVolume.Text = axWindowsMediaPlayer1.settings.volume.ToString() + "%";
                    break;
                case "Próxima musica":
                    if (SelectedMusicFile != MyMusicPaths.Count() - 1)
                    {
                        if (Settings.Default.Shuffle == true)
                        {
                            Ran = rnd.Next(0, MyMusicPaths.Count());
                            SelectedMusicFile = Ran;
                        }
                        else if (Settings.Default.Shuffle == false)
                        { SelectedMusicFile += 1; }
                        axWindowsMediaPlayer1.URL = MyMusicPaths[SelectedMusicFile];
                    }
                    break;
                case "musica Anterior":
                    if (SelectedMusicFile != 0)
                    {
                        SelectedMusicFile -= 1;
                        axWindowsMediaPlayer1.URL = MyMusicPaths[SelectedMusicFile];
                    }
                    break;
                case "Ir mais rápido":
                    axWindowsMediaPlayer1.Ctlcontrols.fastForward();
                    break;
                case "Parar musica":
                    tmrMusic.Stop();
                    axWindowsMediaPlayer1.URL = String.Empty;
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    lblMusicTime.Visible = false; 
                    lblVolume.Visible = false;
                    axWindowsMediaPlayer1.Visible = false;
                    tbarVolume.Visible = false; 
                    tbarMusicTime.Visible = false;
                    axWindowsMediaPlayer1.fullScreen = false;
                    break;
                case "Tela cheia":
                    try
                    {
                        axWindowsMediaPlayer1.fullScreen = true;
                    }
                    catch { }
                    break;
                case "Sair da Tela cheia":
                    axWindowsMediaPlayer1.fullScreen = false;
                    break;
                case "Qual musica está tocando":
                    string filesourceURL = axWindowsMediaPlayer1.currentMedia.sourceURL;
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    { Jarvis.SpeakAsync(MyMusicNames[SelectedMusicFile]); }
                    else
                    { Jarvis.SpeakAsync("Nenhuma musica está tocando agora"); }
                    break;
                #endregion

                #region Other Commands
                case "Quero adicionar um comando editável":
                case "Quero adicionar novos comandos":
                case "Quero adicionar um comandos":
                    Customize customwindow = new Customize();
                    customwindow.ShowDialog();
                    break;

                case "Actualizar Comandos":
                    Jarvis.SpeakAsync("Isso pode levar alguns segundos");
                    _recognizer.UnloadGrammar(shellcommandgrammar);
                    _recognizer.UnloadGrammar(webcommandgrammar);
                    _recognizer.UnloadGrammar(socialcommandgrammar);
                    ArrayShellCommands = File.ReadAllLines(scpath);
                    ArrayShellResponse = File.ReadAllLines(srpath);
                    ArrayShellLocation = File.ReadAllLines(slpath);
                    ArrayWebCommands = File.ReadAllLines(webcpath);
                    ArrayWebResponse = File.ReadAllLines(webrpath);
                    ArrayWebURL = File.ReadAllLines(weblpath);
                    ArraySocialCommands = File.ReadAllLines(socpath);
                    ArraySocialResponse = File.ReadAllLines(sorpath);
                    try
                    { shellcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayShellCommands))); _recognizer.LoadGrammar(shellcommandgrammar); }
                    catch
                    { Jarvis.SpeakAsync("Detedetei em uma entrada válida no seu comandos Sell, possivelmente uma linha vazia. Comandos Sell deixarão de funcionar até que isso seja resolvido."); }
                    try
                    { webcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArrayWebCommands))); _recognizer.LoadGrammar(webcommandgrammar); }
                    catch
                    { Jarvis.SpeakAsync("Detedetei em uma entrada válida no seu comandos Web, possivelmente uma linha vazia. Comandos Web, deixarão de funcionar até que isso seja resolvido."); }
                    try
                    { socialcommandgrammar = new Grammar(new GrammarBuilder(new Choices(ArraySocialCommands))); _recognizer.LoadGrammar(socialcommandgrammar); }
                    catch
                    { Jarvis.SpeakAsync("Detedetei em uma entrada válida no seu comandos Social , possivelmente uma linha vazia. Comandos Social deixarão de funcionar até que isso seja resolvido."); }
                    Jarvis.SpeakAsync("Todos novos comandos foram Actualizados");
                    break;

                case "Actualizar Bibliotecas":
                    Jarvis.SpeakAsync("Carregar Bibliotecas");
                    try { _recognizer.UnloadGrammar(MusicGrammar); _recognizer.UnloadGrammar(VideoGrammar); }
                    catch { Jarvis.SpeakAsync("Gramática Prévia erá inválida"); }
                    File.Delete(@"C:\Users\" + Environment.UserName + "\\Documents\\Reíven Comandos Editáveis\\Filenames.txt");
                    QEvent = "ReadDirectories";
                    ReadDirectories();
                    break;
                case "Mudar directorio de video":
                    Jarvis.SpeakAsync("Porfavor, escolha um directório que estão seus ficheiros de videos para serem carregados");
                    VideoFBD.SelectedPath = Settings.Default.VideoFolder;
                    VideoFBD.Description = "Por favor selecione seu directório de video";
                    DialogResult videoresult = VideoFBD.ShowDialog();
                    if (videoresult == DialogResult.OK)
                    {
                        Settings.Default.VideoFolder = VideoFBD.SelectedPath; Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;
                case "Mudar directorio de musica":
                    Jarvis.SpeakAsync("Porfavor, escolha um directório que estão seus ficheiros de musicas para serem carregados");
                    MusicFBD.SelectedPath = Settings.Default.MusicFolder;
                    MusicFBD.Description = "Por favor selecione seu directório de musica";
                    DialogResult musicresult = MusicFBD.ShowDialog();
                    if (musicresult == DialogResult.OK)
                    {
                        Settings.Default.MusicFolder = MusicFBD.SelectedPath; Settings.Default.Save();
                        QEvent = "ReadDirectories";
                        ReadDirectories();
                    }
                    break;

                case "Pare de Ouvir":
                    Jarvis.SpeakAsync("Ficarei a espera das suas ordens. Quando me chamar diz o meu nome duas vezes seguidas.");
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                    break;
                #endregion

                #region Gmail Notification
                case "Verificar novos email":
                    QEvent = "Checkfornewemails";
                    Jarvis.SpeakAsyncCancelAll();
                    EmailNum = 0;
                    RSSReader.CheckForEmails();
                    break;
                case "Abrir o email":
                    try
                    {
                        Jarvis.SpeakAsyncCancelAll();
                        Jarvis.SpeakAsync("Certo");
                        System.Diagnostics.Process.Start(MsgLink[EmailNum]);
                    }
                    catch { Jarvis.SpeakAsync("Não há emails para serem lidos"); }
                    break;
                case "Ler o email":
                    Jarvis.SpeakAsyncCancelAll();
                    try
                    {
                        Jarvis.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { Jarvis.SpeakAsync("Não há emails para serem lidos"); }
                    break;
                case "Próximo email":
                    Jarvis.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum += 1;
                        Jarvis.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum -= 1; Jarvis.SpeakAsync("Não há nenhum email adicional"); }
                    break;
                case "Email anterior":
                    Jarvis.SpeakAsyncCancelAll();
                    try
                    {
                        EmailNum -= 1;
                        Jarvis.SpeakAsync(MsgList[EmailNum]);
                    }
                    catch { EmailNum += 1; Jarvis.SpeakAsync("Não há nenhum email anterior"); }
                    break;
                case "Limpar lista de email":
                    Jarvis.SpeakAsyncCancelAll();
                    MsgList.Clear(); MsgLink.Clear(); lstCommands.Items.Clear(); EmailNum = 0; Jarvis.SpeakAsync("Lista de Email limpa com sucesso");
                    break;
                #endregion

                #region Updating
                case "Escolher Edioma":
                    AskForACountry();
                    break;
           /*   case "Ir a Página da Antold":
                    Jarvis.SpeakAsync("Deixa-me ver se a ANTOLD publicou alguma coisa");
                    RSSReader.CheckBloggerForUpdates();
                    break;
                case "Sim":
                    if (QEvent == "UpdateYesNo")
                    {
                        Jarvis.SpeakAsync("Obrigado por visitar a nossa página. A Equipe ANTOLD desenvolve aplicativos Android para Empresas, e são especializado em Engenharia Reversa");
                        System.Diagnostics.Process.Start(Settings.Default.RecentUpdate);
                        QEvent = "OpenBlog";
                    }
                   else if (QEvent == "OpenBlog")
                    {
                        Jarvis.SpeakAsync("Very well, consider it done");
                        System.Diagnostics.Process.Start("http://facebook.com/Antold.DG");
                        QEvent = String.Empty;
                    }
                   else if (QEvent == "shutdown" || QEvent == "logoff" || QEvent == "restart")
                    {
                        Jarvis.SpeakAsync("I will begin the countdown to " + QEvent);
                        ShutdownTimer.Enabled = true;
                        lblTimer.Visible = true;
                    }
                    break;
                case "Não":
                    if (QEvent == "UpdateYesNo")
                    {
                        Jarvis.SpeakAsync("Very well. I guess I don't need any improvement");
                        Settings.Default.RecentUpdate = String.Empty; Settings.Default.Save();
                        QEvent = String.Empty;
                    }
                    else if (QEvent == "OpenBlog")
                    {
                        Jarvis.SpeakAsync("Learn by doing I suppose");
                        QEvent = String.Empty;
                    }
                    else if (QEvent == "shutdown" || QEvent == "logoff" || QEvent == "restart")
                    {
                        Jarvis.SpeakAsync("My mistake");
                        QEvent = String.Empty;
                    }
                    break; */
                #endregion
            }
        }
        void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            switch (speech)
            {
                case "Reíven Reíven":
                    startlistening.RecognizeAsyncCancel();
                    Jarvis.SpeakAsync("Sim?");
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    break;
            }
        }
    }
}