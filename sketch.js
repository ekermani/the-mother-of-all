// p5.serial().list(function(data) {
//   console.log('serial list:');
//   data.ports.forEach(function(port) {
//     console.log(port.comName);
//   });
// });


// Board setup — USB port where Arduino connected
var b = p5.board('/dev/cu.usbmodemFA131', 'arduino');

// // two sides
// var leftBuffer;
// var rightBuffer;

// video
var water;
var oil;
var playing = false;

var button = b.pin(9, 'DIGITAL', 'INPUT');

// Sensor
var pmeter = b.pin(0, 'VRES');; // potentiometer 


function setup() {
  // createCanvas(1200, 1200);
  // noStroke();
  // leftBuffer = createGraphics(600, 600);
  // rightBuffer = createGraphics(600, 600);

  // specify multiple formats for different browsers
  water = createVideo(['assets/water2.mov', 'assets/water2.webm']);
  // oil = createVideo(['assets/water2.mov', 'assets/water2.webm']);

  // water.loop(); // loop video
  // water.hide(); // play video within p5

  // button = createButton('play');
  // button.mousePressed(toggleVid); // attach button listener

  // var innerStr = '<p style="font-family:Arial;font-size:12px">'
  //   innerStr += 'Check the console &nbsp; | &nbsp;'
  //   // innerStr += 'press any key to test threshold</p>';
  //   innerStr += 'Press for Red &nbsp; | &nbsp;';
  // // innerStr += 'Release for Blue &nbsp; | &nbsp;';
  // // innerStr += 'Hold for Green </p>';
  // // innerStr += '<b>&larr;</b> Write F to console &nbsp; | &nbsp;';
  // // innerStr += '<b>&rarr;</b> Write C to console &nbsp; | &nbsp;';
  // // innerStr += '<b>&uarr;</b> Write raw value to console &nbsp; | &nbsp;';
  // // innerStr += '<b>&darr;</b> Write K to console </p>';
  // // innerStr += 'Press the button</p>';

  // createDiv(innerStr);

  // pmeter.read(function(val) { 
  //   console.log('pmeter read', val)
  // });
  // pmeter.range([10, 400]);

  // function redEllipse() {
  //   console.log('pressed');
  //   clear();
  //   noStroke();
  //   fill(255, 0, 0);
  //   ellipse(100, 100, 40, 40);
  // }

  // function blueEllipse() {
  //   console.log('released');
  //   clear();
  //   noStroke();
  //   fill(0, 0, 255);
  //   ellipse(200, 100, 40, 40);
  // }

  // function greenEllipse() {
  //   console.log('held')
  //   clear();
  //   noStroke();
  //   fill(0, 255, 136);
  //   ellipse(300, 100, 40, 40);
  // }
  
  pmeter.read(function(val) { 
    console.log('pmeter read', val)
    if (val >= 600) {
      toggleVid();
      // toggleVidOil();
    } else {
      console.log("not playing");
    }
    // else if (val < 600) {
    //   blueEllipse();
    // }
  });

}


// plays or pauses the video depending on current state
function toggleVid() {
  if (playing) {
    water.pause();
    // oil.loop();
    // water.hide();
    // button.html('play');
  } else {
    water.loop();
    // oil.pause();
    // button.html('pause');
  }
  playing = !playing;
}

// function toggleVidOil() {
//   if (playing) {
//     oil.loop();
//   } else {
//     oil.pause();
//     // button.html('pause');
//   }
//   playing = !playing;
// }


// function draw() {
//   background(0);
//   // image(water, 40, 40);
// }