import kotlin.math.ceil
import kotlin.math.log

fun main() {
    val n = readLine()!!.toDouble()
    println(ceil(log(n, 2.0)).toInt() + 1)
}