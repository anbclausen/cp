fun main() {
    val lines = generateSequence(::readLine).toList().drop(1)
    for (line in lines.reversed()) {
        println(line)
    }
}