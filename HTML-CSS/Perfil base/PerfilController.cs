        // [Route("Perfil-Publicacoes")]
        // public List<Publicacao> ListarPublicacao()
        // {
        //     List<Publicacao> postagens = new List<Publicacao>();
            
        //     HttpContext.Session.GetString("_IdUsuario");
        //     var id = Publicacao.FindAll(x => x.Split(";")[3] == _IdUsuario);
             

        //     foreach (var item in postagens)
        //     {
        //         string[] linha = item.Split(";");

        //         Publicacao post = new Publicacao();
        //         post.IdPublicacao = int.Parse(linha[0]);
        //         post.Imagem       = linha[1];
        //         post.Legenda      = linha[2];
        //         post.IdUsuario    = int.Parse(linha[3]);
        //         post.Likes        = int.Parse(linha[4]);
                
        //         postagens.Add(post);
        //     }
        //     return postagens;
        // }
