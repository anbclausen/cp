fun main() {
    val (total, n) = readLine()!!.toString().split(" ").map { it.toInt() }
    var sum = 0

    for (i in 0 until n) {
        val rating = readLine()!!.toInt()
        sum += rating
    }

    val diff = total - n
    val low = (sum + diff * (-3f)) / total
    val high = (sum + diff * 3f) / total

    println("$low $high")
}