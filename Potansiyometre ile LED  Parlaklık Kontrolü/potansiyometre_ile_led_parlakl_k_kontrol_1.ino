// Pin tanımlamaları
const int potPin = A0;   // Potansiyometre analog pini
const int ledPin = 9;    // LED PWM pini

int potValue = 0;        // Potansiyometreden okunacak değer
int ledValue = 0;        // LED için PWM değeri

void setup() {
  pinMode(ledPin, OUTPUT); // LED çıkış olarak ayarlanıyor
  Serial.begin(9600);      // Potansiyometre değerini gözlemlemek için
}

void loop() {
  // Potansiyometreden analog değeri oku (0-1023)
  potValue = analogRead(potPin);

  // Analog değeri PWM aralığına dönüştür (0-255)
  ledValue = map(potValue, 0, 1023, 0, 255);

  // LED parlaklığını ayarla
  analogWrite(ledPin, ledValue);

  // Seri monitörde değerleri görüntüle (isteğe bağlı)
  Serial.print("Potansiyometre: ");
  Serial.print(potValue);
  Serial.print(" -> LED PWM: ");
  Serial.println(ledValue);

  delay(10); // Küçük bir gecikme
}
