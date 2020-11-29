-Çalıştırmak için Docker Desktop kurulu olmalıdır.
-Projenin root'unda alttaki komut çalıştırılarak proje ayağa kaldırılabilir.
	-docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

- http://localhost:9000/swagger/index.html linkinden swagger sayfasından endpointler incelenebilir.

- Post methoduda nullable alanlar sayfanın sonundaki RideViewModel'de gözlenebilir.

-Şehirler kordinat olarak girilmeli.
	Örnek:
		Beggining: "0,1"
		Destination: "3,3"

-Güzergahlar aranırken tüm yolları kapsayacak şekilde arama yaptım. 
Basitçe verilen kordinatların x ve y aralıklarında olan tüm seyehatleri getirdim. 
Arama yaparken o düzlemde gittiği yön -aşağı/yukarı veya sola/sağa gitmesi- dikkate alındı.
