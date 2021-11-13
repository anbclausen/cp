fun main() {
    val n = readLine()!!.toInt()
    var list = readLine()!!.toString().split(" ").map { it.toInt() }
    list = list.sorted().reversed().mapIndexed { index: Int, i: Int -> index + 1 + i }
    println(list.max()!! + 1)
}