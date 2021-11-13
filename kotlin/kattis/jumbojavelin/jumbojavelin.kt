fun main() {
    val lines = generateSequence(::readLine).toList().drop(1).map { it.toInt() }
    val res = lines.fold(1) {acc, e -> acc + e - 1 }
    println(res)
}