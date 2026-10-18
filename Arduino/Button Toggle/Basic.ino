int buttonPin = 2;
int ledPin = 13;
bool ledState = false;

void setup() {
  pinMode(buttonPin, INPUT_PULLUP); // button to GND, no resistor needed
  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, ledState);
  Serial.begin(9600);
}

void loop() {
  if (digitalRead(buttonPin) == LOW) { // button pressed
    delay(200); // debounce
    ledState = !ledState;
    digitalWrite(ledPin, ledState);
    Serial.println(ledState ? "ON" : "OFF");
    while (digitalRead(buttonPin) == LOW); // wait for release
  }
}
