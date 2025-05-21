using System;

namespace ChatbotMensagens
{
    public interface Mensagem
    {
        void Exibir();
    }

    public class MensagemTexto : Mensagem
    {
        private string mensagem;
        private DateTime dataEnvio;

        public MensagemTexto(string mensagem)
        {
            this.mensagem = mensagem;
            this.dataEnvio = DateTime.Now;
        }

        public void Exibir()
        {
            Console.WriteLine($"[Texto] {dataEnvio} - {mensagem}");
        }
    }

    public class MensagemVideo : Mensagem
    {
        private string mensagem;
        private string arquivo;
        private string formato;
        private int duracao;

        public MensagemVideo(string mensagem, string arquivo, string formato, int duracao)
        {
            this.mensagem = mensagem;
            this.arquivo = arquivo;
            this.formato = formato;
            this.duracao = duracao;
        }

        public void Exibir()
        {
            Console.WriteLine($"[Vídeo] {mensagem}, Arquivo: {arquivo}, Formato: {formato}, Duração: {duracao}s");
        }
    }

    public class MensagemFoto : Mensagem
    {
        private string mensagem;
        private string arquivo;
        private string formato;

        public MensagemFoto(string mensagem, string arquivo, string formato)
        {
            this.mensagem = mensagem;
            this.arquivo = arquivo;
            this.formato = formato;
        }

        public void Exibir()
        {
            Console.WriteLine($"[Foto] {mensagem}, Arquivo: {arquivo}, Formato: {formato}");
        }
    }

    public class MensagemArquivo : Mensagem
    {
        private string mensagem;
        private string arquivo;
        private string formato;

        public MensagemArquivo(string mensagem, string arquivo, string formato)
        {
            this.mensagem = mensagem;
            this.arquivo = arquivo;
            this.formato = formato;
        }

        public void Exibir()
        {
            Console.WriteLine($"[Arquivo] {mensagem}, Arquivo: {arquivo}, Formato: {formato}");
        }
    }
    public abstract class Canal
    {
        protected string identificador;

        public Canal(string identificador)
        {
            this.identificador = identificador;
        }

        public abstract void Enviar(Mensagem mensagem);
    }

    public class WhatsApp : Canal
    {
        public WhatsApp(string numeroTelefone) : base(numeroTelefone) { }

        public override void Enviar(Mensagem mensagem)
        {
            Console.WriteLine($"Enviando via WhatsApp para {identificador}");
            mensagem.Exibir();
        }
    }

    public class Telegram : Canal
    {
        public Telegram(string identificador) : base(identificador) { }

        public override void Enviar(Mensagem mensagem)
        {
            Console.WriteLine($"Enviando via Telegram para {identificador}");
            mensagem.Exibir();
        }
    }

    public class Facebook : Canal
    {
        public Facebook(string usuario) : base(usuario) { }

        public override void Enviar(Mensagem mensagem)
        {
            Console.WriteLine($"Enviando no Facebook para @{identificador}");
            mensagem.Exibir();
        }
    }

    public class Instagram : Canal
    {
        public Instagram(string usuario) : base(usuario) { }

        public override void Enviar(Mensagem mensagem)
        {
            Console.WriteLine($"Enviando no Instagram para @{identificador}");
            mensagem.Exibir();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mensagem texto = new MensagemTexto("Tenho uma mesnsagem para você!!");
            Mensagem video = new MensagemVideo("Um novo video saiu!!", "video.mp4", "mp4", 90);
            Mensagem foto = new MensagemFoto("postei uma nova foto!!", "imagem.jpg", "jpg");
            Mensagem arquivo = new MensagemArquivo("Documento anexo", "documento.pdf", "pdf");

            Canal whatsapp = new WhatsApp("+551112345678");
            Canal telegram = new Telegram("+551187654321");
            Canal facebook = new Facebook("NomeusUsuario");
            Canal instagram = new Instagram("NomeUsuario");

            whatsapp.Enviar(texto);
            telegram.Enviar(video);
            telegram.Enviar(texto);
            facebook.Enviar(foto);
            instagram.Enviar(arquivo);
        }
    }
}
