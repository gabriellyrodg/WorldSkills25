using System;

public static class InfoProdutos
{
    public static string MostrarInfo()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();
        Console.WriteLine("|     Catálogo De Produtos        |\n--------------------------------------------\n1. Notebook\n2. Monitor\n3. Teclado\n-----------------------------------------\nQual dos 3 produtos hoje deseja saber mais sobre(1, 2, ou 3): ");
        int produto = int.Parse(Console.ReadLine());
        switch (produto)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("PixelBook Aura: Beleza e Potência em Suas Mãos\r\nO PixelBook Aura é um notebook premium que combina um design ultrafino e elegante em liga de magnésio-alumínio com uma deslumbrante tela OLED 4K+ de 14 polegadas (120Hz). Por dentro, ele entrega performance excepcional com um processador Intel Core Ultra 9, placa de vídeo NVIDIA GeForce RTX 5060 e até 64GB de RAM, ideal para criadores e profissionais exigentes. Completo com Wi-Fi 7, Thunderbolt 5 e uma longa duração de bateria, o Aura redefine a experiência de um notebook de alta performance.");
                Menu.back();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Monitor \"SpectraView X1\"\r\nO SpectraView X1 é um monitor de 32 polegadas com um painel QD-OLED curvo 8K que entrega imagens com pretos perfeitos, cores vibrantes (99% DCI-P3) e brilho excepcional (1000 nits de pico). Sua taxa de atualização de 240Hz e tempo de resposta de 0.03ms eliminam qualquer atraso, enquanto a tecnologia Quantum Dot aprimora a precisão das cores. Com conectividade Thunderbolt 5 e um design minimalista de bordas finas, o SpectraView X1 é ideal para criadores de conteúdo, gamers e profissionais que buscam a mais alta fidelidade visual.");
                Menu.back();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Teclado \"TactileFlow Pro\"\r\nO TactileFlow Pro é um teclado mecânico sem fio que redefine o conforto e a precisão. Construído com um chassi de alumínio aeroespacial e switches de baixo perfil \"Silent Tactile\" pre-lubrificados, ele oferece uma experiência de digitação silenciosa e responsiva. Possui iluminação RGB por tecla personalizável, keycaps PBT duráveis e um dial multifuncional para controle de mídia e aplicativos. Sua conectividade tripla (USB-C, Bluetooth 5.3 e 2.4GHz) e bateria de 3000mAh garantem uso contínuo por semanas, tornando-o perfeito para produtividade e jogos de alto nível.");
                Menu.back();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                MostrarInfo();
                break;
        }

        return "";
    }
}
