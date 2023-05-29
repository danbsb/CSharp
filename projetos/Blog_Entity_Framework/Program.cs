using Blog_Entity_Framework.Data;
using Blog_Entity_Framework.models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog_Entity_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                ////CREATE
                //var tag = new Tag { Name = "CSharp", Slug = "csharp" };
                //context.Tags.Add(tag);
                ////Salvar no banco tudo que tá na memória da variável context
                ////é como se fosse o commit, o Add só deixa na memória
                //var row = context.SaveChanges();
                //Console.WriteLine($"{row} linha incluída!!");

                ////UPDATE
                ////Sempre que for atualizar uma informação
                ////ler o item do banco antes e não criar um NEW
                ////usar o que chama de reidratação
                //var tagId = 1;
                //var tag = context.Tags.FirstOrDefault(x => x.Id == tagId);
                //tag.Name = ".Net";
                //tag.Slug = "dotnet";
                //context.Update(tag);
                //context.SaveChanges();
                
                ////DELETE
                //var tagId = 1;
                //var tag = context.Tags.FirstOrDefault(x => x.Id == tagId);
                //context.Remove(tag);
                //context.SaveChanges();

                ////TOLIST
                //var tags = context.Tags.AsNoTracking().ToList();
                ////os 2 funcionam, o de baixo não executa no banco o de cima sim!
                ////o primeiro executa query
                ////var tags = context.Tags;
                ////o ToList() deve ser sempre o ultimo item da busca
                ////exemplo context.Tags.where().ToList()
                //foreach (var tag in tags)
                //{
                //    Console.WriteLine(tag.Name);
                //}
            }
        }
    }
}