# Ocelot Gateway Baglantisi
Ocelot gateway projesini boş bir webapi projesi olarak oluşturdum. 
Nuget üzerinden Ocelot paketini gateway projesi için yükledim. Daha sonra Program.cs üzerinden gerekli configurasyonları ayarladım.
ocelot.json üzerinde gatewaye gelen isteklerin yönlendirileceği endpointlerin ayarlamasını yaptım.

Test ve deployment işini dahada kolaylaştırabilmek için bütün servisleri dockerize ettim. Bir docker-compoze.yaml compose dosyası üzerinden bütün bir projenin tek komutta çalıştırılabilmesini sağladım. (SqlServer'da container olarak çalışıyor, o containera bağlı database'e bütün servislerin bağlı olduğu databaselerin migrationlarını öncesinde yapılmış olması lazım)

# Nasıl Çalıştırabilirsiniz?
Bütün servislerin connection stringlerini kendime göre ayarladığım için öncelikle connection string değiştirilmesi gerekiyor. Servislerin migrationlarının yapılmış olması gerekiyor. 
Bütün servisleri ve ocelot gatewayi çalıştırdıktan sonra 5180 portuna istek atılarak test edilmeli.
Örnek bir istek
```
curl localhost:5180/api/products
```
Yukarıdaki istek productAPI servisindeki kaynaklara erişmenizi sağlayacak.
