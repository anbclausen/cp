use std::io::{self, BufRead};

fn foreachln(f: fn(std::string::String) -> ()) {
  let stdin = io::stdin();
  for line in stdin.lock().lines().map(|l| l.unwrap()) {
    f(line)
  }
}

fn main() {
  foreachln(|line| {
    if &line[..3] == "555" {
      println!("1")
    } else {
      println!("0")
    }
  })
}