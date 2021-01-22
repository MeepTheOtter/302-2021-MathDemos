float valStart = 0;
float valEnd = 500;

float animLength = 5;
float animPlayheadTime = 0;
boolean isTweenPlaying = false;

float prevTime = 0;


void setup() {
  size(500, 500);
}

void draw() { 

  background(128);

  float currTime = millis()/ 1000.0;
  float dt = currTime - prevTime;
  prevTime = currTime;
  
  if (isTweenPlaying) { 
    animPlayheadTime += dt;
    if(animPlayheadTime >= animLength) {
      isTweenPlaying = false;
      animPlayheadTime = animLength;
    }
  }

  float p = animPlayheadTime / animLength;
  
  //manip p
  //p = p * p; //bends curve down- ease in
  //p = 1 - p; //reverses animation
  //p = 1 - (1 - p) * (1 - p); // bends the curve up- ease out
  p = p * p * (3 - 2 * p); //smooth step- ease in, ease out

  float x = lerp(valStart, valEnd, p);
  ellipse(x, height/2.0, 20, 20);
}

void mousePressed() {
  animPlayheadTime = 0;
  isTweenPlaying = true;
}
