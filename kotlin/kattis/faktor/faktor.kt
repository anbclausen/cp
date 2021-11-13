fun main() {
    val (a, i) = readLine()!!.toString().split(" ").map { it.toInt() }
    println(a * (i - 1) + 1)
}