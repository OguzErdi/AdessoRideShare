-�al��t�rmak i�in Docker Desktop kurulu olmal�d�r.
-Projenin root'unda alttaki komut �al��t�r�larak proje aya�a kald�r�labilir.
	-docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

- http://localhost:9000/swagger/index.html linkinden swagger sayfas�ndan endpointler incelenebilir.

- Post methoduda nullable alanalr sayfan�n sonundaki RideViewModel'de g�zlenebilir.

-�ehirler kordinat olarak girilmeli.
	�rnek:
		Beggining: "0,1"
		Destination: "3,3"

-G�zergahlar aran�rken t�m yollar� kapsayacak �ekilde arama yapt�m. 
Basit�e verilen kordinatlar�n x ve y aral�klar�nda olan t�m seyehatleri getirdim. 
Arama yaparken o d�zlemde gitti y�n -a�a��/yukar� veya sola/sa�a gitmesi- dikkate al�nd�.