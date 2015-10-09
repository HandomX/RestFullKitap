using RestFullKitap.Core.Helps;
using RestFullKitap.Core.ViewModels;
using RestFullKitap.DB;
using RestFullKitap.DB.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestFullKitap.Core.Services
{
    public class CadastrarLivrosService
    {
        private KitapContextDB _KitapDB;

        public CadastrarLivrosService()
        {
            _KitapDB = new KitapContextDB();
        }

        public async Task<LivroModel> Cadastrar(LivroModel livroModel)
        {
            
            if (!VerificarISBN(livroModel))
            {
                var mensagemError = new MensagemResposta("error", "ISBN enviado está invalido.");
                throw new DadosIvalidoException(mensagemError);
            }
                
            await VerificarExistenciaDoLivro(livroModel.Isbn);
            
            var livro = new MontadoraDeLivro().MontarEntidadeLivro(livroModel);
            _KitapDB.Livros.Add(livro);
            await _KitapDB.SaveChangesAsync();

            return livroModel;
        }

        private async Task VerificarExistenciaDoLivro(string[] isbns)
        {
            var serviceBuscarLivro = new BuscarLivrosService();
            LivroModel livro = null;

            foreach (var isbn in isbns)
                livro = await serviceBuscarLivro.PesquisarPorISBN(isbn);

            if (!livro.Titulo.Equals(null))
            {
                var mensagemError = new MensagemResposta("error", "Este Livro já está cadastrado.");
                throw new DadosIvalidoException(mensagemError);
            }
        }

        private bool VerificarISBN(LivroModel livroModel)
        {
            ValidadorDeISBN validadorDeIsbn = new ValidadorDeISBN();

            foreach (var isbn in livroModel.Isbn)
                validadorDeIsbn.AddISBN(isbn);

            return validadorDeIsbn.Validar();
        }
    }
}
