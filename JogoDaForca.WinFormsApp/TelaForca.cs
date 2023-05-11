namespace JogoDaForca.WinFormsApp
{
    public partial class TelaForca : Form
    {
        private Forca jogoDaForca;

        public TelaForca()
        {
            InitializeComponent();

            RegistrarEventos();

            jogoDaForca = new Forca();

            ObterPalavraParcial();

            ObterDicaPalavra();

            lblMensagemFinal.Text = "";
        }

        private void RegistrarEventos()
        {
            foreach (Button botao in pnlBotoes.Controls)
            {
                botao.Click += DarPalpite;
                botao.Click += AtualizarBotoesPainel;
            }

            btnReset.Click += ReiniciarJogo;
        }

        #region Eventos

        private void DarPalpite(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            char palpite = botaoClicado.Text[0];

            if (jogoDaForca.JogadorAcertou(palpite) || jogoDaForca.JogadorPerdeu())
                FinalizarJogo();

            ObterPalavraParcial();

            AtualizarForca();
        }

        private void ReiniciarJogo(object? sender, EventArgs e)
        {
            jogoDaForca = new Forca();

            ObterPalavraParcial();

            ObterDicaPalavra();

            AtualizarForca();

            lblMensagemFinal.Text = "";

            pnlBotoes.Enabled = true;

            foreach (Button botao in pnlBotoes.Controls)
                botao.Enabled = true;
        }

        private void AtualizarBotoesPainel(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;

            botaoClicado.Enabled = false;
        }

        #endregion

        private void FinalizarJogo()
        {

            bool jogadorPerdeu = jogoDaForca.JogadorPerdeu();

            if (jogadorPerdeu)
                lblMensagemFinal.ForeColor = Color.Red;
            else
                lblMensagemFinal.ForeColor = Color.Green;

            pnlBotoes.Enabled = false;

            lblMensagemFinal.Text = jogoDaForca.mensagemFinal;
        }

        private void AtualizarForca()
        {
            switch (jogoDaForca.Erros)
            {
                case 1: pbImagemForca.Image = Properties.Resources.forca01; break;
                case 2: pbImagemForca.Image = Properties.Resources.forca02; break;
                case 3: pbImagemForca.Image = Properties.Resources.forca03; break;
                case 4: pbImagemForca.Image = Properties.Resources.forca04; break;
                case 5: pbImagemForca.Image = Properties.Resources.forca05; break;
                case 6: pbImagemForca.Image = Properties.Resources.forca06; break;
                case 7: pbImagemForca.Image = Properties.Resources.forca07; break;

                default:
                    pbImagemForca.Image = Properties.Resources.forca00;
                    break;
            }
        }

        private void ObterPalavraParcial()
        {
            lblPalavraSecreta.Text = jogoDaForca.PalavraParcial;
        }

        private void ObterDicaPalavra()
        {
            lblDica.Text = jogoDaForca.QuantidadeLetras + " letras";
        }

    }
}