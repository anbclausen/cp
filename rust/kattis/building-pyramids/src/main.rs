fn main() {
    let mut inp = String::new();
    std::io::stdin().read_line(&mut inp).unwrap();
    let mut n: i64 = inp.trim().parse().expect("Failed");
    let mut m = 1;
    let mut c = 0;
    while n >= 0 {
        n -= m * m;
        m += 2;
        c += 1;
    }

    println!("{}", c - 1)
}
