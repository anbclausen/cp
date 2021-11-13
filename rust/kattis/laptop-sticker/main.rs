use std::io::{self, BufRead};

fn foreachln(f: fn(std::string::String) -> ()) {
    let stdin = io::stdin();
    for line in stdin.lock().lines().map(|l| l.unwrap()) {
        f(line)
    }
}

fn ivec(s: std::string::String) -> Vec<i64> {
    s.split_whitespace()
        .map(|num| num.parse().unwrap())
        .collect()
}

fn readline() -> String {
    let stdin = io::stdin();
    let mut res = String::new();
    stdin.read_line(&mut res).unwrap();
    return res
}

fn main() {
    foreachln(|line| {
        let nums = ivec(line);
        if nums[0] - nums[2] >= 2 && nums[1] - nums[3] >= 2 {
            println!("1")
        } else {
            println!("0")
        }
    })
}