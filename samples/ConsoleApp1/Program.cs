using Mdl.SimpleMapperGenerator;

Console.WriteLine("Hello, World!");

Foo foo = new Foo() {Id = 4, Data = 5, Data2= "bar"};

FooDto fooDto = MapperFactory.From(foo);

Console.WriteLine(fooDto.Id);
Console.WriteLine(fooDto.Data);
Console.WriteLine(fooDto.Data2);
